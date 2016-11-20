using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Result_Analysis_for_NBA
{
    class Staffs
    {
        public ObjectId _id { get; set; }
        public string staff_id { get; set; }
        public string staff_name { get; set; }
    }
}
