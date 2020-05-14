using Countries.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesPage : ContentPage
    {
        public CountriesPage()
        {
            InitializeComponent();
            FillCountries();
        }

        private async void FillCountries()
        {
            HttpClient client = new HttpClient();

            string url = "https://exam-api.tsc-dev.xyz/api/countries";

            var resultado = await client.GetAsync(url);
            var json = resultado.Content.ReadAsStringAsync().Result;

            Datum model = Datum.FromJson(json);

            listCountries.ItemsSource = model.Data;
        }

        //private async void Agregar_Clicked(object sender, EventArgs e)
        
        //  {
        //    Datum country = new Datum();
        //    country.Name = "Panama";
        //    country.Alpha2 = "PNM";
        //    country.Alpha3 = "PNM";
        //    country.Code = 123;
        //    country.Iso3166_2 = "https://en.wikipedia.org/wiki/ISO_3166-2:SV";
        //    country.IsIndependent = true;


        //    HttpClient client = new HttpClient();

        //    string url = "https://exam-api.tsc-dev.xyz/api/countries";

        //    string jsonCountry = JsonConvert.SerializeObject(country);
        //    var result = await client.PostAsync(url, new StringContent(jsonCountry));
        //    var json = result.Content.ReadAsStringAsync().Result;


        //    await DisplayAlert("Notification", json, "Ok");

        //    FillCountries();
        //}

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddPage()));
        }
    }
}