using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Configuration;

namespace WindowsFormsApplicationDemo.MongoDB
{
    public class GetMongoDB
    {
        public IMongoDatabase GetDB()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString;
            var client = new MongoClient(connStr);
            var database = client.GetDatabase(new MongoUrl(connStr).DatabaseName);
            return database;
        }
    }
}
