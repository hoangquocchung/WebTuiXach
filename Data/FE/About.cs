namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Metatitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        [StringLength(250)]
        public string ModifiledBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        public bool? Status { get; set; }
    }
}
