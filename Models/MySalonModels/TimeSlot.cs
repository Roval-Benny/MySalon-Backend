using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MySalonModels
{
    public class TimeSlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SalonId { get; set; }
        public int ServiceId { get; set; }
        public string Date { get; set; }
        public bool Time9To11 { get; set; }
        public bool Time11To1 { get; set; }
        public bool Time2To4 { get; set; }
        public bool Time4To6 { get; set; }
    }
}
