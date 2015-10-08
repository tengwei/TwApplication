namespace TransactionTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        public bool Deleted { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int CreateId { get; set; }

        public int UpdateId { get; set; }

        public int ProductTypeId { get; set; }
    }
}
