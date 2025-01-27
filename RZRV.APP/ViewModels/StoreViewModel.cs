
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class StoreViewModel
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
        [ValidateNever]
        [Display(Name = "Products")]
        public List<string> Products { get; set; }
    }
}