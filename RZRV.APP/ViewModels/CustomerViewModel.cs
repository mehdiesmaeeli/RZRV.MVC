
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Referred By Service Provider Id")]
        public List<string> ReferredByServiceProviderId { get; set; }
        [Display(Name = "Referred By Service Provider")]
        public List<string> ReferredByServiceProvider { get; set; }
        [Display(Name = "Reservations")]
        public List<string> Reservations { get; set; }
        [Display(Name = "Orders")]
        public List<string> Orders { get; set; }
    }
}