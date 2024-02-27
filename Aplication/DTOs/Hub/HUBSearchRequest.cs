namespace Domain.Entities.Hub
{
    public class HUBSearchRequest 
    {
        public int hotelId { get; set; }
        public DateTime? checkIn { get; set; }
        public DateTime? checkOut { get; set; }
        public int numberOfGuests { get; set; }
        public int numberOfRooms { get; set; }
        public string currency { get; set; }
    }
   
}


