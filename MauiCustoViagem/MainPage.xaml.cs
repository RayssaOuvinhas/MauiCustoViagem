using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private async void ToolbarItem_Clicked_Salvar(object sender, EventArgs e)
        {
            try
            {
                Pedagio p = new Pedagio
                {
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Rendimento = Convert.ToDouble(txt_rendimento.Text),
                    Preco_Comb = Convert.ToDouble(txt_preco_comb.Text),
                };

                await App.db.Insert(p);
                await DisplayAlert("Sucesso!", "Pedagio Salvo!", "OK");
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }

        private async void ToolbarItem_Clicked_Ver(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.VerPedagio());
        }
    }
}
