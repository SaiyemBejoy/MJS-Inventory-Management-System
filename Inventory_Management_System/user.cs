//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_Management_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int u_id { get; set; }
        public string u_name { get; set; }
        public string u_username { get; set; }
        public string u_password { get; set; }
        public string u_phone { get; set; }
        public string u_email { get; set; }
        public byte u_status { get; set; }
        public byte u_roleID { get; set; }
    
        public virtual role role { get; set; }
    }
}
