using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Esame_Pierluigi_Ghiani
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        RestService service;
        public ObservableCollection<Product> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();
            service = new RestService();
            Items = new ObservableCollection<Product>();
            BindingContext = this;
            LoadProducts();
        }

        private async void LoadProducts()
        {
            var products = await service.GetProductsAsync();
            Items.Clear();
            foreach (var p in products)
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
            var products = await service.GetProductsAsync();
            // Puoi gestire i prodotti qui come preferisci
        }
    }
}
