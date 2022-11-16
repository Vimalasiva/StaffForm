using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StaffForm.Core.Model
{
    
   public  class StaffModel
    {
        
        //[JsonPropertyOrder()]-->To change the order of fields in swagger.
        //[JsonPropertyOrder(2)]//
        public int ID { get; set; }
        //[JsonPropertyOrder(1)]
        public string? Name { get; set; }
        //[JsonPropertyOrder(4)]
        public int Age { get; set; }
        //[JsonPropertyOrder(3)]
        public string? Gender { get; set; }
        //[JsonPropertyOrder(6)]
        public string? Qualification { get; set; }
        //[JsonPropertyOrder(5)]
        public string? CompanyName { get; set; }
        //[JsonPropertyOrder(8)]
        public DateTime JoiningDate { get; set; }
        //[JsonPropertyOrder(7)]
        public string? Role { get; set; }
        //[JsonPropertyOrder(10)]
        public int Experience { get; set; }
        //[JsonPropertyOrder(9)]
        public string? Address { get; set; }
        //[JsonPropertyOrder(12)]
        public long MobileNo { get; set; }
        //[JsonPropertyOrder(11)]
        public string? EmailID { get; set; }
        //[JsonPropertyOrder(14)]
        public string? Password { get; set; }
        //[JsonPropertyOrder(13)]
        public string? RePassword { get; set; }
        //[JsonPropertyOrder(16)]
        public string? Location { get; set; }
        //[JsonPropertyOrder(15)]
        public int StaffLocationID { get; set; }
        //[JsonPropertyOrder(17)]
        public string? Datestr { get; set; }
        //[JsonPropertyOrder(20)]
        public bool Is_Deleted { get; set; }
        //[JsonPropertyOrder(18)]
        public DateTime Created_Time_Stamp { get; set; }
        //[JsonPropertyOrder(19)]
        public DateTime Updated_Time_Stamp { get; set; }
      
        //[JsonIgnore]//--->When this attribute is used the particular property is hidden from swagger.
       
    }
}
