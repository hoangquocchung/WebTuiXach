namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuUser")]
    public partial class MenuUser
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public long? FrameViewID { get; set; }

        public long? ParentID { get; set; }

        public int? Type { get; set; }

        public int? Level { get; set; }

        [StringLength(6)]
        public string Target { get; set; }

        [StringLength(100)]
        public string SeoTitle { get; set; }

        public bool Satus { get; set; }

        [StringLength(2)]
        public string Language { get; set; }
    }
}
