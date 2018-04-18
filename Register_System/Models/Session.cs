namespace Register_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Session")]
    public partial class Session
    {
        public int SessionId { get; set; }

        public int UserID { get; set; }

        
        [StringLength(40)]
        [Required(ErrorMessage = "Please enter title of the session")]
        public string SessionTitle { get; set; }

        
        [StringLength(20)]
        [Required(ErrorMessage = "Must be entered")]
        public string SessionDate { get; set; }

        [Required(ErrorMessage = "Please enter the description of the session")]
        [StringLength(100)]
        public string SessionDescription { get; set; }

        [Required(ErrorMessage = "This must be entered")]
        public int UniqueCode { get; set; }

        public virtual User User { get; set; }
    }
}
