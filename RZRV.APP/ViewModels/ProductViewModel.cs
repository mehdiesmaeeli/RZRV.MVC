
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RZRV.APP.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }
        [Display(Name = "Store Id")]
        public int StoreId { get; set; }
        [ValidateNever]
        [Display(Name = "Store")]
        public List<Store> Store { get; set; }
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [ValidateNever]
        [Display(Name = "Category")]
        public List<Category> Category { get; set; }
    }
}