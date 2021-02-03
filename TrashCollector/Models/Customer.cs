using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {        
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Balance Due")]
        public int Balance { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }


        public string Address { get; set; }


        //[Display(Name = "Weekly Pickup Day")]
        //public DayOfWeek WeeklyPickupDay { get; set; }
        [NotMapped]
        public SelectList Days { get; set; }

        [ForeignKey("Day")]
        [Display(Name = "Regular Pickup Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }


        public bool AdditionalPickup { get; set; }

        [Display(Name = "Extra Pickup Day(Optional)")]
        public DateTime ExtraPickupDay { get; set; }


        public bool SuspendedPickup { get; set; }

        [Display(Name = "Suspend Pickup Start Day(Optional)")]
        public DateTime SuspendPickupStart { get; set; }


        [Display(Name = "Suspend Pickup End Day(Optional)")]
        public DateTime SuspendPickupEnd { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
