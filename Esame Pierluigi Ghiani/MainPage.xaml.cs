namespace Esame_Pierluigi_Ghiani
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        RestService service;
        List<Product> Items;

        public MainPage()
        {
            InitializeComponent();
           service = new RestService();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var service = new RestService();
            var products = await service.GetProductsAsync();
        }

    }
}
