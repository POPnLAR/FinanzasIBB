using FinanzasIBB.Models;
using FinanzasIBB.Validations;
using Firebase.Auth;

namespace FinanzasIBB.Views;

public partial class LoginPage : ContentPage
{
    private readonly FirebaseAuthClient _clientAuth;
    public Usuario usuario { get; set; }
    public LoginPage(FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();
        _clientAuth = firebaseAuthClient;
    }

    

    private async void RegisterUser_Clicked(object sender, EventArgs e)
    {
        usuario = (new Usuario
        {
            Email = EntryEmail.Text,
            Password = EntryPass.Text
        });
        string results = validatorLogin(usuario);

        if (results != null)
        {
            await Application.Current.MainPage.DisplayAlert("Registro", results, "OK");
        }
        else
        {
            try
            {
                var userFind = await _clientAuth.FetchSignInMethodsForEmailAsync(usuario.Email);
                if (!userFind.UserExists)
                {
                    var userRecord = await _clientAuth.CreateUserWithEmailAndPasswordAsync(usuario.Email, usuario.Password);
                    await Application.Current.MainPage.DisplayAlert("Registro", $"Usuario Registrado: {userRecord.User.Uid}", "OK");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Registro", "Correo ya Existe", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Registro", "Correo ya Existe, prueba con otro", "OK");
            }
        }
    }

    private async void ButtonLogin_Clicked(object sender, EventArgs e)
    {
        usuario = (new Usuario
        {
            Email = EntryEmail.Text,
            Password = EntryPass.Text
        });
        string results = validatorLogin(usuario);
        if (results != null)
        {
            await Application.Current.MainPage.DisplayAlert("Registro", results, "OK");
        }
        else
        {
            try
            {
                var userRecord = await _clientAuth.SignInWithEmailAndPasswordAsync(usuario.Email, usuario.Password);
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de Sesion", "Email y/o Password Incorrecto", "OK");
            }
        }
    }

    private string? validatorLogin(Usuario usuario) 
    {
        string error = string.Empty;
        LoginValidator loginValidator = new LoginValidator();

        FluentValidation.Results.ValidationResult results = loginValidator.Validate(usuario);

        if (!results.IsValid)
        {
            foreach (var failure in results.Errors)
            {
                error += "*" + failure.ErrorMessage + "\n";
            }
           return error;
        }
        return null;
    }
}