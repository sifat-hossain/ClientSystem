using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientSystem.Models
{
    [MetadataType(typeof(MetadataUserProfile))]
    public partial class UserProfile
    {
    }
    public class MetadataUserProfile
    {
        [DataType(DataType.Text)]
        public string UserFirstName { get; set; }
        [DataType(DataType.Text)]
        public string UserLastName { get; set; }
        [DataType(DataType.MultilineText)]
        public string UaserAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int UserPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime UserDOB { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}