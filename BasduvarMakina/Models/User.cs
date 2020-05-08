using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BasduvarMakina.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string Image { get; set; }
    }
}