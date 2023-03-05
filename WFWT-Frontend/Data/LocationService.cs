namespace WFWT_Frontend.Data;

public class LocationService
{
    private readonly HttpClient _httpClient;
    public LocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Location[]> GetLocationsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<Location[]>("location");
        return response ?? Array.Empty<Location>();
    }

    public async Task<Location?> GetLocationAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<Location>($"location/{id}");
        return response;
    }

    public async Task<Location?> CreateLocationAsync(Location location)
    {
        var response = await _httpClient.PostAsJsonAsync<Location>("location", location);
        return await response.Content.ReadFromJsonAsync<Location>();
    }

    public async Task<Location?> UpdateLocationAsync(Location location)
    {
        var response = await _httpClient.PutAsJsonAsync<Location>($"location/{location.id}", location);
        return await response.Content.ReadFromJsonAsync<Location>();
    }

    public async Task<Location?> DeleteLocationAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"location/{id}");
        return await response.Content.ReadFromJsonAsync<Location>();
    }
}