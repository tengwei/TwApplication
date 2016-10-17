namespace TransactionTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderPost")]
    public partial class OrderPost
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int CreateId { get; set; }

        public int UpdateId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
