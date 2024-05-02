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
                //await Navigation.PushAsync(new MainPage());

                //double Litro = lista_viagens.Sum(i => (i.Preco / i.Rendimento));
                //double custo = lista_viagens.Sum(i => (Litro * i.Distancia));
                //string msg = $"O custo total da viagem é {custo:C}";
                //DisplayAlert("Custo", msg, "Fechar");

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
    }
}
//double quilometro = lista_pedagios.Sum(i => (i.Preco_Comb / i.Rendimento));
//double custo = lista_pedagios.Sum(i => (quilometro * i.Distancia));
//string msg = $"O custo total da viagem é {custo:C}";
//DisplayAlert("Custo", msg, "Fechar");