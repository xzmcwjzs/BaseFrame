using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using WindowsFormsApplicationDemo.MongoDB;

namespace WindowsFormsApplicationDemo
{
    public partial class MongoDBDemo : Form
    {
        public MongoDBDemo()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            users model = new users()
            {
                id = "45",
                name = "form窗体测试新增",
                password = "123456",
                age = 24,
                createtime = DateTime.Now
            };
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            try
            {
                collection.InsertOne(model);
                MessageBox.Show("新增成功");
            }
            catch (Exception)
            {
                MessageBox.Show("新增失败");
            } 
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            DeleteResult result = collection.DeleteOne<users>(t => t.id == "45");
            if (result.DeletedCount > 0)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users"); 
            UpdateDefinition<users> definition = "{$set:{'name':'更新测试','password':'1456666','age':32,'createtime':'" + DateTime.Now + "'}}"; 
            var result = collection.UpdateOne<users>(t => t.id =="45", definition);
            if (result.ModifiedCount > 0)
            {
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("更新失败");
            }
        }

        private void Query_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            try
            {
                var result = collection.Find<users>(t => t.id == "45").FirstOrDefault();
                string name = result.name.ToString();
                MessageBox.Show(name);
            }
            catch (Exception)
            {
                MessageBox.Show("查询失败");
            }
           
        }
    }
}
