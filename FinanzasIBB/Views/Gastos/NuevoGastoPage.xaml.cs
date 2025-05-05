using Firebase.Database;
using Firebase.Database.Query;
using FinanzasIBB.Models;

namespace FinanzasIBB.Views.Gastos;

public partial class NuevoGastoPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://ibbelbosque-24ffd-default-rtdb.firebaseio.com/");
    public List<TipoGasto> TipoGastos { get; set; }

    public NuevoGastoPage()
	{
		InitializeComponent();

        CargarTipoGastos();
        BindingContext = this;
	}

    public void CargarTipoGastos()
    {
        var tipoGastos = client.Child("TipoGasto").OnceAsync<TipoGasto>();
        TipoGastos = tipoGastos.Result.Select(x => x.Object).ToList();
        FamGastos.ItemsSource = TipoGastos;
    }

    private async void GuardarButton_Clicked(object sender, EventArgs e)
    {
        TipoGasto? tipoGasto = FamGastos.SelectedItem as TipoGasto;
        await client.Child("Gastos").PostAsync(new Gasto
        {
            NombreGasto = nomGasto.Text,
            DetalleGasto = DetGasto.Text,
            ValorGasto = double.Parse(ValorGasto.Text),
            FecVencimientoGasto = FecVencimientoGasto.Date,
            FecPagoGasto = FecPagoGasto.Date,
            TipoGasto = tipoGasto,
        });

        await Navigation.PopAsync();
    }

}