using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MySalonModels
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public string UserName { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public string ServiceName { get; set; }
        public string Price { get; set; }
        public string Offer { get; set; }

    }
}
