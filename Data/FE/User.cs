namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(150)]
        public string Username { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(550)]
        public string Addess { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        [StringLength(50)]
        public string Group { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        [StringLength(250)]
        public string ModifiledBy { get; set; }

        public bool Status { get; set; }
    }
}
