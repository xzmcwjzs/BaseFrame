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
using ntu.xzmcwjzs.ADODAL;
using ntu.xzmcwjzs.Model.Entities;
using System.Diagnostics;
using System.Threading;

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
         
        private void button1_Click(object sender, EventArgs e)
        { 
            List<Test> listModel = new List<Test>();

            int count = 500000;
            for (int i = 0; i < count; i++)
            {
                Test model = new Test();
                 
                model.id = i.ToString();
                model.name = "sqlserver";
                model.password = "123456";
                model.id_card_num = "321323199308175315";
                model.birthdate = DateTime.Now;
                model.photo = "sqlserver的批量插入测试";
                model.createtime = DateTime.Now;
                listModel.Add(model);
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SqlHelper.InsertBySqlBulkCopy<Test>(listModel, "Test");
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用sqlserver批量插入10W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string sql = "delete from Test";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null); 
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用sqlserver批量删除100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string sql = "update Test set name='sqlserverupdate' where id=9999";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用sqlserver单条更新100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string sql = "select * from Test where id='9999'";
            DataSet ds = SqlHelper.GetDataSet(CommandType.Text, sql,null);
            string name= ds.Tables[0].Rows[0][1].ToString(); 
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用sqlserver查询100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<users> listModel = new List<users>();

            int count = 500000;
            for (int i = 0; i < count; i++)
            {
                users model = new users();

                model.id = i.ToString();
                model.name = "mongodb";
                model.password = "123456";
                model.age = i;
                model.createtime = DateTime.Now;
                listModel.Add(model);
            }
             
            var database = new GetMongoDB().GetDB(); 
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            collection.InsertMany(listModel);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用mongodb批量插入50W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DeleteResult result = collection.DeleteMany<users>(t => true);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用mongodb批量删除100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        public class users
        {
            public string id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public int age { get; set; }
            public DateTime createtime { get; set; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            UpdateDefinition<users> definition = "{$set:{'name':'mongodbupdate','password':'123456','age':32,'createtime':'" + DateTime.Now + "'}}";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = collection.UpdateOne<users>(t => t.id == "9999", definition);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用mongodb单条更新100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = collection.Find<users>(t => t.id == "9999"); 
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "使用mongodb查询100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }
        private static object o1 = new object();
        private static object o2 = new object();
        private void button9_Click(object sender, EventArgs e)
        {
            int count = 10;
            int n = 1000;
            Stopwatch sw = new Stopwatch();
             
            Task[] tasks = new Task[n];
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => {
                  
                        for (int j = 0; j < count; j++)
                        {
                            string sql = "insert into Test (id,name,password,id_card_num,birthdate,photo,createtime) values ('" + Guid.NewGuid().ToString() + "','sqlserver','123456','321323199308154756','" + DateTime.Now + "','sqlserver的批量插入测试','" + DateTime.Now + "') ";

                            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
                        }
                    
                });

                //Thread newThread = new Thread(() => {
                //    lock (o1)
                //    {
                //        for (int j = 0; j < count; j++)
                //        {
                //            string sql = "insert into Test (id,name,password,id_card_num,birthdate,photo,createtime) values ('" + Guid.NewGuid().ToString() + "','sqlserver','123456','321323199308154756','" + DateTime.Now + "','sqlserver的批量插入测试','" + DateTime.Now + "') ";

                //            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
                //        }
                //    }
                    
                //});

                //newThread.Start();
            } 
            Task.WaitAll(tasks); 
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "1000个并发连接对关系型数据库sqlserver批量插入1w条数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
            
            int count = 10;
            int n = 1000;
            Stopwatch sw = new Stopwatch();
            Task[] tasks = new Task[n];
            sw.Start();

            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    
                        for (int j = 0; j < count; j++)
                        {
                            users model = new users()
                            {
                                id = Guid.NewGuid().ToString(),
                                name = "mongodb",
                                password = "123456",
                                age = i,
                                createtime = DateTime.Now
                            };
                            collection.InsertOne(model);
                        }
                   
                });
                //Thread newThread = new Thread(() => {
                //    lock (o2)
                //    {
                //        for (int j = 0; j < count; j++)
                //        {
                //            users model = new users()
                //            {
                //                id = Guid.NewGuid().ToString(),
                //                name = "mongodb",
                //                password = "123456",
                //                age = i,
                //                createtime = DateTime.Now
                //            };
                //            collection.InsertOne(model);
                //        } 
                //    }
                //});

                //newThread.Start();
            }
            Task.WaitAll(tasks);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "1000个并发连接对非关系型数据库mongodb批量插入1W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<Test> listModel = new List<Test>();

            int count = 1000000;
            for (int i = 0; i < count; i++)
            {
                Test model = new Test();

                model.id = Guid.NewGuid().ToString();
                model.name = "sqlserver";
                model.password = "123456";
                model.id_card_num = "321323199308175315";
                model.birthdate = DateTime.Now;
                model.photo = "sqlserver的并发批量插入测试";
                model.createtime = DateTime.Now;
                listModel.Add(model);
            }
            Stopwatch sw = new Stopwatch();
            int n = 100;
            Task[] tasks = new Task[n];
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task.Factory.StartNew(()=> {
                    SqlHelper.InsertBySqlBulkCopy<Test>(listModel, "Test");
                });
            }
            
            Task.WaitAll(tasks);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "100个并发连接对关系型数据库sqlserver批量插入100w条数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<users> listModel= new List<users>();
            int count = 1000;
            for (int j = 0; j < count; j++)
            {
                users model = new users(); 
                model.id = Guid.NewGuid().ToString();
                model.name = "mongodb";
                model.password = "123456";
                model.age = j;
                model.createtime = DateTime.Now;
                listModel.Add(model);
            }

            var database = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = database.GetCollection<users>("users");
             
            int n = 100;
            Stopwatch sw = new Stopwatch();
            Task[] tasks = new Task[n];
            sw.Start();
             
            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    foreach (var item in listModel)
                    {
                        lock (o1)
                        {
                            collection.InsertOne(item);
                        } 
                    } 
                }); 
            }
            Task.WaitAll(tasks);
            sw.Stop();
            var temp = sw.Elapsed;
            string time = "100个并发连接对非关系型数据库mongodb批量插入100W数据总耗时为：" + temp.ToString();
            Console.WriteLine(time);
        }


    }
}
