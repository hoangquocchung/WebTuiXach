namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? TypeOfAdvID { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        [StringLength(550)]
        public string ImageID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiledDate { get; set; }

        [StringLength(250)]
        public string ModifiledBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        public bool Status { get; set; }
    }
}
