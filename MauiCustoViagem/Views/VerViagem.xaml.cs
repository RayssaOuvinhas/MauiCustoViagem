using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem.Views;

public partial class VerViagem : ContentPage
{
    ObservableCollection<Viagem> lista_viagens = new ObservableCollection<Viagem>();
    public VerViagem()
	{
		InitializeComponent();
        lst_viagem.ItemsSource = lista_viagens;
    }

    protected async override void OnAppearing()
    {
        if (lista_viagens.Count == 0)
        {
            List<Viagem> tmp = await App.db.GetAll();
            foreach (Viagem p in tmp)
            {
                lista_viagens.Add(p);
            }
        }
    }
    private async void MenuItem_Clicked_Remover(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = (MenuItem)sender;
            Viagem p = selecionado.BindingContext as Viagem;

            bool confirm = await DisplayAlert("Tem certeza?", "Remover Viagem?", "Sim", "Cancelar");

            if (confirm)
            {
                await App.db.Delete(p.Id);
                await DisplayAlert("Sucesso", "Viagem Removida", "Ok");
                lista_viagens.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void lst_viagem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Viagem? p = e.SelectedItem as Viagem;

        Navigation.PushAsync(new MainPage
        {
            BindingContext = p
        });
    }
}