using System;

namespace RZRV.APP.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}