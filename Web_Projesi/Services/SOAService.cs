namespace Web_Projesi.Services;

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.Json;
using System.Net.Http;

public class SOAService
{
    private readonly HttpClient _httpClient;
    private const string API_URL = "http://localhost:3000/validate";

    public SOAService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> DogrulaAsync(long tckimlikNo, string ad, string soyad, int dogumYili)
    {
        try
        {
            var requestData = new
            {
                tcNo = tckimlikNo.ToString(),
                firstName = ad,
                lastName = soyad,
                birthYear = dogumYili
            };

            var jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            Console.WriteLine($"Gönderilen veri: {jsonContent}");

            var response = await _httpClient.PostAsync(API_URL, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Servis yanıtı: {jsonResponse}");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<ValidateResponse>(jsonResponse, options);
                return result?.Result ?? false;
            }
            else
            {
                Console.WriteLine($"HTTP Hata: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            return false;
        }
    }
}

public class ValidateResponse
{
    [System.Text.Json.Serialization.JsonPropertyName("isValid")]
    public bool Result { get; set; }
}