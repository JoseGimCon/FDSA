using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.HotelLegsSearch
{
    public class HotelLegsSearchRequest
    {
            public int hotel { get; set; }
            public string checkInDate { get; set; }
            public int numberOfNights { get; set; }
            public int guests { get; set; }
            public int rooms { get; set; }
            public string currency { get; set; }

    }
}
