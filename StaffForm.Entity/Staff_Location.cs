﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StaffForm.Entity
{
    public partial class Staff_Location
    {
        public Staff_Location()
        {
            StaffDetailTable = new HashSet<StaffDetailTable>();
        }

        public int Staff_Location_ID { get; set; }
        public string Working_Location { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Created_Time_Stamp { get; set; }
        public DateTime Updated_Time_Stamp { get; set; }

        public virtual ICollection<StaffDetailTable> StaffDetailTable { get; set; }
    }
}