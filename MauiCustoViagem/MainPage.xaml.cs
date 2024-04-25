namespace MauiCustoViagem
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked_Ver(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CalcularCusto());
        }

        private void ToolbarItem_Clicked_Custo(object sender, EventArgs e)
        {
            
        }
    }
}
