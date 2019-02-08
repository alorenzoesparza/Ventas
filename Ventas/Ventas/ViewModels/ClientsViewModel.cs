using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Ventas.Common.Models;
using Ventas.Services;
using Xamarin.Forms;

namespace Ventas.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private ApiService apiService;

        private bool refrescar;

        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients
        {
            get { return this.clients; }
            set { this.SetValue(ref this.clients, value); }
        }

        public bool Refrescar
        {
            get { return this.refrescar; }
            set { this.SetValue(ref this.refrescar, value); }
        }

        public ClientsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClients();
        }

        private async void LoadClients()
        {
            this.Refrescar = true;

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Aceptar");
                return;
            }

            var urlApi = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetList<Client>(urlApi, "/api", "/Clients");
            if (!response.IsSuccess)
            {
                this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }


            var lista = (List<Client>)response.Result;

            //List<Client> seleccion = lista.FindAll(x => x.ZoneId == 1);

            //foreach (var item in lista)
            //{
            //    if (item.ZoneId == 2)
            //    {
            //        seleccion.Add(item);
            //    }
            //}
            //var zona = lista[1].ZoneId;


            //lista = lista.OrderBy(o => o.Apellidos).ToList();
            this.Clients = new ObservableCollection<Client>(lista);
            this.Refrescar = false;
        }

        public ICommand ComandoRefrescar
        {
            get
            {
                return new RelayCommand(LoadClients);
            }
        }
    }
}
