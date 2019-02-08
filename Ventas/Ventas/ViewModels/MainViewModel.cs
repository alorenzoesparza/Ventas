namespace Ventas.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;

    public class MainViewModel
    {
        public ClientsViewModel Clients { get; set; }
        public ProductsViewModel Products { get; set; }
        public AddClientViewModel AddClients { get; set; }

        #region Constructor
        public MainViewModel()
        {
            this.Clients = new ClientsViewModel();
        }
        #endregion

        public ICommand ComandoNuevoCliente
        {
            get
            {
                return new RelayCommand(GoToNuevoCliente);
            }
        }

        private async void GoToNuevoCliente()
        {
            this.AddClients = new AddClientViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AddClientPage());
        }
    }
}
