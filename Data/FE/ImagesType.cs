namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImagesType")]
    public partial class ImagesType
    {
        [Key]
        public long ImageTypeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public long? ParentID { get; set; }

        public bool? Statust { get; set; }
    }
}
