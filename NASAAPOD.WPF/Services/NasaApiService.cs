using NasaAPOD.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPOD.WPF.Services;

public class NasaApiService
{
    public const string BASE_URL = "https://api.nasa.gov/planetary/";

    public const string APOD_ENDPOINT = "apod?api_key={0}";

    public static async Task<AstronomyPictureOfTheDay> GetAPOD(string apiKey, AstronomyPictureOfTheDay astronomyPictureOfTheDay)
    {
        string url = BASE_URL + string.Format(APOD_ENDPOINT, apiKey);

        using (HttpClient httpClient = new())
        {
            var response = await httpClient.GetAsync(url);

            string json = await response.Content.ReadAsStringAsync();

            astronomyPictureOfTheDay = JsonConvert.DeserializeObject<AstronomyPictureOfTheDay>(json);
        }

        return astronomyPictureOfTheDay;
    }
}
