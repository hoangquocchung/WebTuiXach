namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public long ID { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Height { get; set; }

        public int? Width { get; set; }

        [StringLength(50)]
        public string Path { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        public long? ImageTypeID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Alt { get; set; }

        [StringLength(180)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Caption { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
