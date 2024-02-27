using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Hub
{
    public class HUBSearchResponse
    {
        public List<Room> Rooms { get; set; }
    }
    public class Rate
    {
        public int MealPlanId { get; set; }
        public bool IsCancellable { get; set; }
        public double Price { get; set; }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public List<Rate> Rates { get; set; }
    }

}
