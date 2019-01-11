namespace Ventas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Ventas.Common.Models;
    using Ventas.Services;
    using Xamarin.Forms;

    public class ClientsViewModel : BaseViewModel
    {
        private ApiService apiService;

        private ObservableCollection<Client> clients;

        //public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Client> Clients
        {
            get { return this.clients; }
            set { this.SetValue(ref this.clients, value); }
        }

        public ClientsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClients();
        }

        private async void LoadClients()
        {
            var response = await this.apiService.GetList<Client>("http://antonioleapi.somee.com", "/api", "/Clients");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var lista = (List<Client>)response.Result;
            //lista = lista.OrderBy(o => o.Apellidos).ToList();
            this.Clients = new ObservableCollection<Client>(lista);
        }
    }
}
