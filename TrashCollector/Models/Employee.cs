using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        public List<string> DailyPickupLocations { get; set; }//add variable List<> of pickup locations for the day -- using google maps API?
        public int ZipCode { get; set; } //might need additional variables for google map API
        public string CurrentDayOfWeek { get; set; }
        public bool CompletedPickup { get; set; } //if completed pickup add charge to customer

    }
}
