//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UaserAddress { get; set; }
        public int UserPhone { get; set; }
        public string UserEmail { get; set; }
        public System.DateTime UserDOB { get; set; }
        public string UserPassword { get; set; }
    }
}