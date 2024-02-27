using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.HotelLegsSearch
{
    public class HotelLegsSearchResponse
    {
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public int room { get; set; }
        public int meal { get; set; }
        public bool canCancel { get; set; }
        public float price { get; set; }
    }
}
