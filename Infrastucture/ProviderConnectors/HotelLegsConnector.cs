using Domain.HotelLegsSearch;
using Infrastucture.ProviderConectors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastucture.ProviderConectors
{
    public class HotelLegsConnector : IHotelLegsConnector
    {
        public async Task<HotelLegsSearchResponse> Search(HotelLegsSearchRequest request)
        {

            HotelLegsSearchResponse hotelLegsSearchResponse = Search();
            
            return hotelLegsSearchResponse;
        }

        private HotelLegsSearchResponse Search()
        {
            string filePath = GetPatch();
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"This file was not found. path: {filePath}");

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<HotelLegsSearchResponse>(json);
        }

        private string GetPatch()
        {

            string relativePath = @"\Files\HotelLegsRessponseJson.json";

            string currentDirectory = Directory.GetCurrentDirectory();

            return currentDirectory + relativePath;
        }
    }
}
