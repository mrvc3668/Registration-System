namespace Register_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TempSession")]
    public partial class TempSession
    {
        [Key]
        public int TempSessId { get; set; }

        [Required]
        [StringLength(40)]
        public string TempSessTitle { get; set; }

        [Required]
        [StringLength(20)]
        public string TempSessDate { get; set; }

        [Required]
        [StringLength(100)]
        public string TempSessDescription { get; set; }

        public int TempSessCode { get; set; }
    }
}
