using System;
using MongoDB;
using MongoDB.Driver;

namespace BLL
{
    public class Conexoes
    {
        public string mongoConnectionName { get { return "mongodb://localhost:27017"; } }

        public MongoClient mongoConn()
        {
            return new MongoClient(this.mongoConnectionName);
        }
    }
}
