using MauiCustoViagem.Models;

namespace MauiCustoViagem.Views;

public partial class NovoPedagio : ContentPage
{
	public NovoPedagio()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked_Salvar(object sender, EventArgs e)
    {
        try
        {
            Pedagio p = new Pedagio
            {
                Local = txt_Local.Text,
                Valor = Convert.ToDouble(txt_Valor.Text),
            };

            await App.dbPedagio.Insert(p);
            await DisplayAlert("Tudo certo", "Pedágio inserido", "Fechar");
            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }

    private void ToolbarItem_Clicked_Calculo(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new MainPage());
        //double Litro = lista_viagens.Sum(i => (i.Preco / i.Rendimento));
        //double Custo = lista_viagens.Sum(i => (Litro * i.Distancia + i.Pedagio));
        //string msg = $"O custo total do pedagio é {Custo:C}";
        //await DisplayAlert("Custo", msg, "Fechar");
    }
}