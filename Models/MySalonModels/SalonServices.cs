using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MySalonModels
{
    public class SalonServices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Offer { get; set; }
        public string Image { get; set; }
        [Required]
        public Service ServiceId { get; set; }
        public Salon SalonId { get; set; }
        public string SalonName { get; set; }
    }
}
