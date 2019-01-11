namespace Ventas.Infrastructure
{
    using ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        #region Contructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
