namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QandA")]
    public class QandA
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Phone { get; set; }
        
        [StringLength(500)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime? CreateDated { get; set; }

        public bool Status { get; set; }
    }
}
