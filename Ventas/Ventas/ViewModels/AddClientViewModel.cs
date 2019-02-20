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
        #region Servicios
        private ApiService apiService;
        #endregion

        #region Atributos
        private ObservableCollection<Zone> zones;
        private ObservableCollection<Periodicity> periodicities;
        private ObservableCollection<string> mensaje;
        private ObservableCollection<bool> activo;
        private string hola;
        private bool activado;
        private bool activarErrorNombre;
        private bool activarErrorApellidos;
        private string textoErrorNombre;
        private string textoErrorApellidos;
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

        public string Hola
        {
            get { return this.hola; }
            set { this.SetValue(ref this.hola, value); }
        }

        public bool Activado
        {
            get { return this.activado; }
            set { this.SetValue(ref this.activado, value); }
        }

        public bool ActivarErrorNombre
        {
            get { return this.activarErrorNombre; }
            set { this.SetValue(ref this.activarErrorNombre, value); }
        }

        public bool ActivarErrorApellidos
        {
            get { return this.activarErrorApellidos; }
            set { this.SetValue(ref this.activarErrorApellidos, value); }
        }

        public string TextoErrorNombre
        {
            get { return this.textoErrorNombre; }
            set { this.SetValue(ref this.textoErrorNombre, value); }
        }

        public string TextoErrorApellidos
        {
            get { return this.textoErrorApellidos; }
            set { this.SetValue(ref this.textoErrorApellidos, value); }
        }

        public ObservableCollection<String> Mensaje
        {
            get { return this.mensaje; }
            set { this.SetValue(ref this.mensaje, value); }
        }

        public ObservableCollection<bool> Activo
        {
            get { return this.activo; }
            set { this.SetValue(ref this.activo, value); }
        }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public int SelectedZoneId { get; set; }

        public int SelectedPeriodicityId { get; set; }
        #endregion

        public AddClientViewModel()
        {
            this.apiService = new ApiService();
            this.Activado = true;
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

        private void GoToGuardarCliente()
        {
            var mensaje = new List<string>();
            var activo = new List<bool>();
            for (int i = 0; i < 5; i++)
            {
                mensaje.Add(string.Empty);
                activo.Add(false);
            }

            if (string.IsNullOrEmpty(Nombre))
            {
                activo[0] = true;
                mensaje[0] = "El campo nombre no puede estar en blanco";
            }

            if (string.IsNullOrEmpty(Apellidos))
            {
                activo[1] = true;
                mensaje[1] = "El campo Apellidos no puede estar en blanco";
            }

            this.Mensaje = new ObservableCollection<string>(mensaje);
            this.Activo = new ObservableCollection<bool>(activo);
            //Mensaje.Add("Vamos ");
            this.Hola = "Vamos a ver si funciona";
            //Mensaje[0] = ("Hola a todos");
            //this.AddClients = new AddClientViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new AddClientPage());
        }
    }
}
