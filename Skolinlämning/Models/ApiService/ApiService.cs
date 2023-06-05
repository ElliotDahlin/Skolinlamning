using Newtonsoft.Json;
using Skolinlämning.Models;
using System.Collections.Generic;


public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Root> GetDriversAsync()
    {
        var response = await _httpClient.GetAsync("https://ergast.com/api/f1/2023/drivers.json");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var drivers = JsonConvert.DeserializeObject<Root>(content);

        return drivers;
    }
}
