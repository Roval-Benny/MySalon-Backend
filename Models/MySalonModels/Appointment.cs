using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MySalonModels
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Status { get; set; }
    }
}
