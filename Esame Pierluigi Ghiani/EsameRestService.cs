
using Esame_Pierluigi_Ghiani;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RestService

{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public RestService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://fakestoreapi.com/")
        };
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("products");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Product>>(content, _jsonOptions);
    }


}