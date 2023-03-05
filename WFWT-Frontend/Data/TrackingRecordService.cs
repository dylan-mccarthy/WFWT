namespace WFWT_Frontend.Data;

public class TrackingRecordService
{
    private readonly HttpClient _httpClient;
    public TrackingRecordService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TrackingRecord[]> GetTrackingRecordsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<TrackingRecord[]>("trackingrecord");
        return response ?? Array.Empty<TrackingRecord>();
    }

    public async Task<TrackingRecord?> GetTrackingRecordAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<TrackingRecord>($"trackingrecord/{id}");
        return response;
    }

    public async Task<TrackingRecord?> CreateTrackingRecordAsync(TrackingRecord trackingRecord)
    {
        var response = await _httpClient.PostAsJsonAsync<TrackingRecord>("trackingrecord", trackingRecord);
        return await response.Content.ReadFromJsonAsync<TrackingRecord>();
    }

    public async Task<TrackingRecord?> UpdateTrackingRecordAsync(TrackingRecord trackingRecord)
    {
        var response = await _httpClient.PutAsJsonAsync<TrackingRecord>($"trackingrecord/{trackingRecord.id}", trackingRecord);
        return await response.Content.ReadFromJsonAsync<TrackingRecord>();
    }

    public async Task<TrackingRecord?> DeleteTrackingRecordAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"trackingrecord/{id}");
        return await response.Content.ReadFromJsonAsync<TrackingRecord>();
    }
}