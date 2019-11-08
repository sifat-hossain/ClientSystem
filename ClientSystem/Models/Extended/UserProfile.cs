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
        [Required]
        [DataType(DataType.Text)]
        [StringLength(10,ErrorMessage ="Please Insert a valid Name",MinimumLength =1)]
        public string UserFirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Please Insert a valid Name", MinimumLength = 1)]
        public string UserLastName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string UaserAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
       
        public int UserPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime UserDOB { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}