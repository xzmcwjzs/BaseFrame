using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    public partial class Crawler : Form
    {
        private string destDir;//目标文件夹
        public Crawler()
        {
            InitializeComponent();
        }

        private void btnSelectDesdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDesdir.Text = dlg.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入关键词");
                return;
            }
             destDir = txtDesdir.Text;
            if (string.IsNullOrEmpty(destDir))
            {
                MessageBox.Show("请选择要保存的文件夹"); return;
            }

            if (!destDir.EndsWith("\\"))
            {
                destDir = destDir+ "\\"+keyword + "\\";
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

            }
            //避免阻塞主线程
            //Thread thread = new Thread(()=> {
            //    ProcessDownload(keyword);
            //});
            //thread.Start();
            Action downloadAction = new Action(() => {
                ProcessDownload(keyword);
            });

            AsyncCallback callBack = new AsyncCallback(asyncResult =>
              {
                  downloadAction.EndInvoke(asyncResult);
                  progressBar.BeginInvoke(new Action(() => {
                      progressBar.Value = progressBar.Maximum;
                  }));

                  txtLog.BeginInvoke(new Action(() =>
                  {
                      txtLog.AppendText("下载图片操作结束！" + Environment.NewLine);
                  }));
                  btnStart.BeginInvoke(new Action(() =>
                  {
                      btnStart.Enabled = true;
                  }));

              });

            IAsyncResult result = downloadAction.BeginInvoke(callBack, null);
            txtLog.AppendText("正在下载图片中..." + Environment.NewLine);

        }

        private void ProcessDownload(string keyword)
        {
            int pageCount = (int)numPagecount.Value;
            for (int i = 0; i < pageCount; i++)
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://image.baidu.com/search/acjson?tn=resultjson_com&ipn=rj&ct=201326592&is=&fp=result&queryWord=" + Uri.EscapeDataString(keyword) + "&cl=2&lm=-1&ie=utf-8&oe=utf-8&adpicid=&st=&z=&ic=&word=" + Uri.EscapeDataString(keyword) + "&s=&se=&tab=&width=&height=&face=&istype=&qc=&nc=&fr=&cg=girl&pn=" + (i + 1) * 30 + "&rn=30&gsm=5a&1492178555149=");

                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            try
                            {
                                DownloadPage(stream);
                            }
                            catch (Exception ex)
                            {
                                txtLog.BeginInvoke(new Action(() =>
                                {
                                    txtLog.AppendText(ex.Message + Environment.NewLine);
                                }));
                            }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("获取第" + i + "页失败：" + response.StatusCode);
                    }
                }

            }
        }
         
        private void DownloadPage(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                JObject objRoot = (JObject)JsonConvert.DeserializeObject(json);
                JArray imgs = (JArray)objRoot["data"];
                for (int i = 0; i < imgs.Count; i++)
                {
                    JObject img =(JObject)imgs[i];
                    string objUrl = (string)img["thumbURL"];
                    //txtLog.AppendText(objUrl + Environment.NewLine);
                    try
                    {
                        DownloadImage(objUrl);
                    }
                    catch (Exception ex)
                    {
                        txtLog.BeginInvoke(new Action(() =>
                        {
                            txtLog.AppendText(ex.Message + Environment.NewLine);
                        }));
                    }
                    
                }
            } 

        } 

        private void DownloadImage(string objURL)
        { 
                string destFile = Path.Combine(destDir, Path.GetFileName(objURL));
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(objURL);
                webRequest.Referer = "https://image.baidu.com/";
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (FileStream fStream = new FileStream(destFile, FileMode.Create))
                            {
                                stream.CopyTo(fStream);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("下载" + objURL + "失败，错误码：" + response.StatusCode);
                    }
                }
             
        }
    }
}
