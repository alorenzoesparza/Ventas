namespace Ventas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Common.Models;
    using Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        #region Servicios
        private ApiService apiService;
        #endregion

        #region Atributos
        private ObservableCollection<Product> products;
        public bool refrescar;
        #endregion

        #region Propiedades
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }

        public bool Refrescar
        {
            get { return this.refrescar; }
            set { this.SetValue(ref this.refrescar, value); }
        }

        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }
        #endregion

        #region Metodos
        private async void LoadProducts()
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

            var response = await this.apiService.GetList<Product>(
                urlApi,
                "/api",
                "/Products");
            if (!response.IsSuccess)
            {
                this.Refrescar = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    response.Message, 
                    "Aceptar");
                return;
            }

            var list = (List<Product>)response.Result;
            // Convertir la lista en ObservableCollection
            this.Products = new ObservableCollection<Product>(list);
            this.Refrescar = false;
        }
        #endregion
    }
}
