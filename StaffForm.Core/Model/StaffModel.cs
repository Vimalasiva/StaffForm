using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StaffForm.Core.Model
{
   public  class StaffModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string CompanyName { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Role { get; set; }
        public int Experience { get; set; }
     
        public string Address { get; set; }
        public long MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Created_Time_Stamp { get; set; }
        public DateTime Updated_Time_Stamp { get; set; }
        public string Datestr { get; set; }
        public string? Location { get; set; }
        public int StaffLocationID { get; set; }
    }
}
