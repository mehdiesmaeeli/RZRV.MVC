using System.Collections.Generic;

namespace RZRV.APP.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? ReferredByServiceProviderId { get; set; }
        public virtual ServiceProvider ReferredByServiceProvider { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}