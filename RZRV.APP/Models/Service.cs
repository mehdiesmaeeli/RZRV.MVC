using System;

namespace RZRV.APP.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public int ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }
}