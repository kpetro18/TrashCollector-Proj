using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        //add variable of pickup locations for the day -- using google maps API?
        [Key]
        public int EmployeeId { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; } //might need additional variables for google map API
        //public string CurrentDayOfWeek { get; set; } //can use C# methods to get this info so doesnt need to be stored on DB


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }
}
