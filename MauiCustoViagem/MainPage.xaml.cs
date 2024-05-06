using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Viagem> lista_viagens = new ObservableCollection<Viagem>();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked_Salvar(object sender, EventArgs e)
        {
            try
            {
                Viagem p = new Viagem
                {
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Rendimento = Convert.ToDouble(txt_rendimento.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                    Pedagio = Convert.ToDouble(txt_pedagio.Text),
                };

                await App.db.Insert(p);
                await Navigation.PushAsync(new MainPage());
                //await DisplayAlert("Viagem inserida","Fechar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }

        private async void ToolbarItem_Clicked_Ver(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.VerViagem());
        }

        private async void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.NovoPedagio());
        }
    }
}
