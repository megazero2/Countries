using Countries.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private const string url = "https://exam-api.tsc-dev.xyz/api/countries";
        public Datum countries { get; set; }
        public string Name { get; set; }
        public string Alpha2 { get; set; }
        public string Alpha3 { get; set; }
        public long Code { get; set; }
        public string Iso3166_2 { get; set; }
        public bool IsIndependent { get; set; }
        public AddPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            countries = new Datum
            {
                Name = this.Name,
                Alpha2 = this.Alpha2,
                Alpha3 = this.Alpha3,
                Code = this.Code,
                Iso3166_2 = this.Iso3166_2,
                IsIndependent = this.IsIndependent
            };
            var serializeItem = JsonConvert.SerializeObject(countries);
            StringContent body = new StringContent(serializeItem, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(url, body);
            string data = await result.Content.ReadAsStringAsync();
            if(result.IsSuccessStatusCode)
            {
                var answer = await DisplayAlert("Sucess", "Do you want to continue", "yes", "No");
                if(answer)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new CountriesPage()));
                }
                else
                {

                }
            }
        }
    }
}