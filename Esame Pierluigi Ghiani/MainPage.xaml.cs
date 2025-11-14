using Microsoft.Maui.Controls;

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
            BindingContext = this;
        }

        protected async void OnNavigatedTo(Object sender, NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            var products = await service.GetProductsAsync();
            foreach(var p in products)
            {
                Items.Add(p);
            }
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not Product item) return;

            await Shell.Current.GoToAsync(nameof(ProductPage), true, new Dictionary<string, object>
            {
                ["Item"] = item
            });
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var service = new RestService();
            var products = await service.GetProductsAsync();
        }

    }
}
