using FinanzasIBB.Views;
using FinanzasIBB.Views.Gastos;
using FinanzasIBB.Views.Ingresos;

namespace FinanzasIBB
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Rutas de acceso
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(NuevoGastoPage), typeof(NuevoGastoPage));
            Routing.RegisterRoute(nameof(VerGastoPage), typeof(VerGastoPage));
            Routing.RegisterRoute(nameof(EditarGastoPage), typeof(EditarGastoPage));
            Routing.RegisterRoute(nameof(NuevoIngresoPage), typeof(NuevoIngresoPage));
            Routing.RegisterRoute(nameof(VerIngresoPage), typeof(VerIngresoPage));
        }
    }
}
