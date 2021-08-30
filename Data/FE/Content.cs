namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Metatitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Images { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        [StringLength(250)]
        public string ModifiledBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        public bool Status { get; set; }

        public bool IsHome { get; set; }

        public int? ViewConut { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [StringLength(2)]
        public string Language { get; set; }
    }
}
