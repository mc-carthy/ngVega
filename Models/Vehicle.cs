using System;
using System.ComponentModel.DataAnnotations;

namespace ngVega.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        // The model is included so that we don't have to import a new Model 
        // object from the DbContext when populating the edit vehicle form
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}