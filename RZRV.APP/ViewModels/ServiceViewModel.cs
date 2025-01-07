
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class ServiceViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Duration")]
        public List<string> Duration { get; set; }
        [Display(Name = "Service Provider Id")]
        public int ServiceProviderId { get; set; }
        [Display(Name = "Service Provider")]
        public List<string> ServiceProvider { get; set; }
    }
}