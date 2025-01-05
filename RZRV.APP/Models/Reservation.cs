using System;

namespace RZRV.APP.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public ReservationStatus Status { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled
    }
}