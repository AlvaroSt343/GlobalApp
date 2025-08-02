namespace GlobalApp.Services;

public class SessionService
{
    // Devuelve si el usuario está logueado
    public bool IsLogged => Preferences.Default.Get("isLogged", false);

    // Establece el estado de sesión a "logueado"
    public void Login() => Preferences.Default.Set("isLogged", true);

    // Elimina el estado de sesión (cerrar sesión)
    public void Logout() => Preferences.Default.Remove("isLogged");
}
