
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RZRV.APP.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }


        [ValidateNever]
        [Display(Name = "Products")]
        public List<Product> Products { get; set; }
    }
}