using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsumoApi.models;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;

namespace ConsumoApi
{
    public partial class MainPage : ContentPage
    {
        private const string BaseUrl = "https://randomuser.me/api/";

        public MainPage()
        {
            InitializeComponent();
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                models.RandomUserResponse response = await GetAsync<models.RandomUserResponse>("?results=5"); // Ajusta el número de resultados según sea necesario

                var personList = response.results.Select(person => new
                {
                    Name = $"{person.name.first} {person.name.last}",
                    Location = $"{person.location.city}, {person.location.state}"
                }).ToList();

                CollectionViewDemo.ItemsSource = personList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Considera mostrar un mensaje al usuario aquí
            }
        }
    }
}