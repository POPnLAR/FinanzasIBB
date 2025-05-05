using Firebase.Database;
using FinanzasIBB.Views.Gastos;

namespace FinanzasIBB.Views;

public partial class MainPage : ContentPage
{
    private readonly FirebaseClient _client;
    public MainPage()
	{
		InitializeComponent();
    }

    private async void VerGastos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerGastoPage());
    }
}