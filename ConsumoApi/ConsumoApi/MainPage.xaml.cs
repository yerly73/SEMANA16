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
        public MainPage()
        {
            InitializeComponent();

        }

        private const string BaseUrl = "https://rickandmortyapi.com";

        public async Task<T> GetAsync<T>(string endpoint)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                // Realizar la solicitud GET al servidor
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Leer y deserializar la respuesta JSON
                    string json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    // Manejar errores
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            try
            {
                //ResponseBase results = await GetAsync<ResponseBase>("https://rickandmortyapi.com/api/character");
                // Procesar el resultado

                List<ResponseBase> results = await GetAsync<List<ResponseBase>>("https://rickandmortyapi.com/api/character");

                var animeList = results.Select(anime => new
                {
                    Id = anime.id,
                    Status = anime.status,
                    Species = anime.species,
                    Image = anime.image,
                    Episode = anime.episode
                }).ToList();

                //ListViewDemo.ItemsSource = gameList;
                CollectionViewDemo.ItemsSource = animeList;



            }
            catch (Exception ex)
            {
                throw ex;
                // Manejar errores
            }
        }
    }
}