using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem.Views;

public partial class VerPedagio : ContentPage
{
    ObservableCollection<Pedagio> lista_pedagios = new ObservableCollection<Pedagio>();
    public VerPedagio()
	{
		InitializeComponent();
        lst_pedagios.ItemsSource = lista_pedagios;
    }

    private void ToolbarItem_Clicked_Custo(object sender, EventArgs e)
    {
        double quilometro = lista_pedagios.Sum(i => (i.Preco_Comb / i.Rendimento));
        double custo = lista_pedagios.Sum(i => (quilometro * i.Distancia));
        string msg = $"O custo total da viagem é {custo:C}";
        DisplayAlert("Custo", msg, "Fechar");
    }
    protected async override void OnAppearing()
    {
        if (lista_pedagios.Count == 0)
        {
            List<Pedagio> tmp = await App.db.GetAll();
            foreach (Pedagio p in tmp)
            {
                lista_pedagios.Add(p);
            }
        }
    }
    private async void MenuItem_Clicked_Remover(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = (MenuItem)sender;
            Pedagio p = selecionado.BindingContext as Pedagio;

            bool confirm = await DisplayAlert("Tem certeza?", "Remover Pedagio?", "Sim", "Cancelar");

            if (confirm)
            {
                await App.db.Delete(p.Id);
                await DisplayAlert("Sucesso", "Pedagio Removido", "Ok");
                lista_pedagios.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void lst_pedagios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Pedagio? p = e.SelectedItem as Pedagio;

        Navigation.PushAsync(new MainPage
        {
            BindingContext = p
        });
    }
}