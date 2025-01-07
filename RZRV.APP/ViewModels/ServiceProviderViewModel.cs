
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class ServiceProviderViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Contact Info")]
        public string ContactInfo { get; set; }
        [Display(Name = "Services")]
        public List<string> Services { get; set; }
        [Display(Name = "Offered Products")]
        public List<string> OfferedProducts { get; set; }
    }
}