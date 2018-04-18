namespace Register_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Sessions = new HashSet<Session>();
        }

        public int UserId { get; set; }

        [StringLength(31)]
        [Required(ErrorMessage = "Username must be atleast 8 characters")]

        public string UserName { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Please enter your password, must be at least 10 characters")]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords Do not match")]
        public string ConfirmPassword { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter your division")]
        public string Division { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter your position")]
        public string Position { get; set; }

        public int UserType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
