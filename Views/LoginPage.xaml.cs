namespace JGualpa_TS2_PA.Views;

public partial class LoginPage : ContentPage
{
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] claves = { "carlos123", "ana123", "jose123" };

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string user = txtUsuario.Text?.Trim();
        string pass = txtClave.Text;

        for (int i = 0; i < usuarios.Length; i++)
        {
            if (string.Equals(user, usuarios[i], StringComparison.OrdinalIgnoreCase) && pass == claves[i])
            {
                await DisplayAlert("Bienvenido", $"Hola {usuarios[i]}, bienvenido al sistema.", "Aceptar");

                // Abre la ventana principal
                await Navigation.PushAsync(new vCalificaciones(usuarios[i])); 
                return;
            }
        }
        if (string.IsNullOrEmpty(user))
        {
            await DisplayAlert("Error", "Campos vacíos, ingrese un usuario", "Aceptar");
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "Aceptar");
        }
            
    }
}