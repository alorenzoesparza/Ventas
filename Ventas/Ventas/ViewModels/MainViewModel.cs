namespace Ventas.ViewModels
{
    public class MainViewModel
    {
        public ClientsViewModel Clients { get; set; }

        #region Constructor
        public MainViewModel()
        {
            this.Clients = new ClientsViewModel();
        }
        #endregion
    }
}
