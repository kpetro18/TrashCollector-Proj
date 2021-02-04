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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; } //might need additional variables for google map API
        //public string CurrentDayOfWeek { get; set; } //can use C# methods to get this info so doesnt need to be stored on DB
        public bool CompletedPickup { get; set; } //if completed pickup add charge to customer
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }
}
