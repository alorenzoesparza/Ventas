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
        #endregion

        #region Propiedades
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
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
            var response = await this.apiService.GetList<Product>(
                "http://antonioleapi.somee.com",
                "/api",
                "/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    response.Message, 
                    "Aceptar");
                return;
            }

            var list = (List<Product>)response.Result;
            // Convertir la lista en ObservableCollection
            this.Products = new ObservableCollection<Product>(list);
        }
        #endregion
    }
}
