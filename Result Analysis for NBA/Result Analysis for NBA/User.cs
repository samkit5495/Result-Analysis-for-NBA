using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Result_Analysis_for_NBA
{
    class User
    {  
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public string security { get; set; }
        public string answer { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
    }
}
