
public class RestService

{
    private readonly HttpClient
        private readonly JsonSeralizerOptions _jsonOptions;

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

    public async Task<List<Prdoduct>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("products");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Product>>(content, _jsonOptions);
    }


}