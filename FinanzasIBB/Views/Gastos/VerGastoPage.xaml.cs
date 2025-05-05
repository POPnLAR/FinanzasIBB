using System.Collections.ObjectModel;
using FinanzasIBB.Models;
using Firebase.Database;

namespace FinanzasIBB.Views.Gastos;

public partial class VerGastoPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://ibbelbosque-24ffd-default-rtdb.firebaseio.com/");
    public ObservableCollection<Gasto> ListaGastos { get; set; } = new ObservableCollection<Gasto>();
    public VerGastoPage()
	{
		InitializeComponent();
        BindingContext = this;
        CargarGastos();
    }

    public void CargarGastos()
    {
        client.Child("Gastos")
            .AsObservable<Gasto>()
            .Subscribe((gasto) =>
            {
                if (gasto != null)
                {
                    ListaGastos.Add(gasto.Object);
                }
            });
    }

    private async void NuevoButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoGastoPage());
    }

    private void FiltroBuscar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = FiltroBuscar.Text.ToLower();
        if (filtro.Length > 0)
        {
            ListaGastosCollection.ItemsSource = ListaGastos.Where(x => x.NombreGasto.ToLower().Contains(filtro));
        }
        else
        {
            ListaGastosCollection.ItemsSource = ListaGastos;
        }
    }

    private async void ListaGastosCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Gasto gasto = e.CurrentSelection.FirstOrDefault() as Gasto;
        await Navigation.PushAsync(new EditarGastoPage
        {
            BindingContext = gasto
        });
    }
}