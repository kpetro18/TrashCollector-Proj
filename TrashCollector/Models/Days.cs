using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Days
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public string Name { get; set; }
    }
}
