using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Ventas.Common.Models;
using Ventas.Services;
using Xamarin.Forms;

namespace Ventas.ViewModels
{
    public class AddClientViewModel : BaseViewModel
    {
        #region MyRegion
        private ApiService apiService;
        #endregion

        #region Atributos
        private ObservableCollection<Zone> zones;
        private ObservableCollection<Periodicity> periodicities;
        #endregion

        #region Propiedades
        public ObservableCollection<Zone> Zones
        {
            get { return this.zones; }
            set { this.SetValue(ref this.zones, value); }
        }

        public ObservableCollection<Periodicity> Periodicities
        {
            get { return this.periodicities; }
            set { this.SetValue(ref this.periodicities, value); }
        }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public int SelectedZoneId { get; set; }

        public int SelectedPeriodicityId { get; set; }
        #endregion

        public AddClientViewModel()
        {
            this.apiService = new ApiService();
            this.LoadZones();
            this.LoadPeriodicities();
        }

        private async void LoadZones()
        {
            //this.Refrescar = true;

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                //this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Aceptar");
                return;
            }

            var urlApi = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetList<Zone>(urlApi, "/api", "/Zones");
            if (!response.IsSuccess)
            {
                //this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var lista = (List<Zone>)response.Result;
            //lista = lista.OrderBy(o => o.Apellidos).ToList();
            this.Zones = new ObservableCollection<Zone>(lista);
            //this.Refrescar = false;
        }

        private async void LoadPeriodicities()
        {
            //this.Refrescar = true;

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                //this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Aceptar");
                return;
            }

            var urlApi = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetList<Periodicity>(urlApi, "/api", "/Periodicities");
            if (!response.IsSuccess)
            {
                //this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var lista = (List<Periodicity>)response.Result;
            //lista = lista.OrderBy(o => o.Apellidos).ToList();
            this.Periodicities = new ObservableCollection<Periodicity>(lista);
            //this.Refrescar = false;
        }

        public ICommand ComandoGuardarCliente
        {
            get
            {
                return new RelayCommand(GoToGuardarCliente);
            }
        }

        private async void GoToGuardarCliente()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return;
            }
            //this.AddClients = new AddClientViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new AddClientPage());
        }
    }
}
