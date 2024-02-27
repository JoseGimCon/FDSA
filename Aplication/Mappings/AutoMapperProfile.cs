using AutoMapper;
using Domain.Entities.Hub;
using Domain.HotelLegsSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region HotelLegs
            CreateMap<HUBSearchRequest, HotelLegsSearchRequest>()
               .ForMember(destino =>
                  destino.hotel,
                  opt => opt.MapFrom(origen => origen.hotelId)
               )
               .ForMember(destino =>
                   destino.checkInDate,
                   opt => opt.MapFrom(origen => origen.checkIn)
               )
               .ForMember(destino =>
                   destino.guests,
                   opt => opt.MapFrom(origen => origen.numberOfGuests)
               )
               .ForMember(destino =>
                   destino.rooms,
                   opt => opt.MapFrom(origen => origen.numberOfRooms)
               )
               .ForMember(destino => 
                    destino.numberOfNights,
                    conf => conf.MapFrom(
                 origen => (origen.checkOut - origen.checkIn).Value.TotalDays)
               );
            CreateMap<HotelLegsSearchResponse, HUBSearchResponse>()
                 .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src =>
                     src.results
                         .GroupBy(r => r.room)
                         .Select(group => new Room
                         {
                             RoomId = group.Key,
                             Rates = group.Select(r => new Rate
                             {
                                 MealPlanId = r.meal,
                                 IsCancellable = r.canCancel,
                                 Price = Math.Round(r.price, 2)
                             }).ToList()
                         }).ToList()
             ));

            #endregion
        }    
    }

}
