namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Metatitle { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(4000)]
        public string Images { get; set; }

        [StringLength(4000)]
        public string MoreImages { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

        public bool IncludeVAT { get; set; }

        [StringLength(50)]
        public string CategoryID { get; set; }

        public long? MainMenu { get; set; }

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
    }
}
