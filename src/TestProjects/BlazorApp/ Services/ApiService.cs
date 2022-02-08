using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Planner.Models.Unit;

namespace BlazorApp. Services
{
    public class ApiService
    {
        private readonly HttpClient http;

        public ApiService(HttpClient http) {
            this.http = http;
        }

        public async Task<UnitDto?> GetUnitAsync(string? unitCode) {
            var response = await http.GetAsync($"Handbook/GetUnit/{unitCode}");
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<UnitDto>(responseContent);
        }
    }
}