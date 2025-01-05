using System.Collections.Generic;

namespace RZRV.APP.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Product> OfferedProducts { get; set; }
    }
}