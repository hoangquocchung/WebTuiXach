namespace Data.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string ShipEmail { get; set; }

        [StringLength(150)]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipMobile { get; set; }

        [StringLength(250)]
        public string ShipAddress { get; set; }

        [Column(TypeName = "ntext")]
        public string ghichu { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }

        public bool trahang { get; set; }

        public bool nhanhang { get; set; }
    }
}
