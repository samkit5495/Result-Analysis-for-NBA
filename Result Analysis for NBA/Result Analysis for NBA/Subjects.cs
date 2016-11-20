using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace Result_Analysis_for_NBA
{
    class Subjects
    {
        public ObjectId _id { get; set; }
        public int srno { get; set; }
        public string academic_year { get; set; }
        public string clas { get; set; }
        public string semester { get; set; }
        public string Subject_Name { get; set; }
        public string marks { get; set; }
        public string Staff_Name { get; set; }
    }
}
