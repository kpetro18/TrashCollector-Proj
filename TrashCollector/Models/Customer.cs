using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        public int PaymentDue { get; set; }
        public string WeeklyPickupDay { get; set; }
        public bool AdditionalPickup { get; set; }
        public string ExtraPickupDay { get; set; }
        public bool SuspendedPickup { get; set; }
        public string SuspendedDays { get; set; }
    }
}
