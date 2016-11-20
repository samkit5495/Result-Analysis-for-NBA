using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace Result_Analysis_for_NBA
{
    class Students
    {
        public ObjectId _id { get; set; }
        public string prn { get; set; }
        public string student_name { get; set; }
        public string academicyear { get; set; }
        public string ad_type { get; set; }
        public string migration { get; set; }

    }
}
