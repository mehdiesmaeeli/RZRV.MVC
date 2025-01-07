
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{
    public class ReservationViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Reservation Date Time")]
        public DateTime? ReservationDateTime { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Customer")]
        public List<string> Customer { get; set; }
        [Display(Name = "Service Id")]
        public int ServiceId { get; set; }
        [Display(Name = "Service")]
        public List<string> Service { get; set; }
        [Display(Name = "Status")]
        public List<string> Status { get; set; }
    }
}