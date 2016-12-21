using System;
using Xamarin.Forms;

namespace Charts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            XAML.Clicked += XAML_Clicked;
            CSharp.Clicked += CSharp_Clicked;
        }
        private async void CSharp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Barchart());
        }

        private async void XAML_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BarChartPage());
        }
    }
}
