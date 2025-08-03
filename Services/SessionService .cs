namespace GlobalApp.Services
{
    public class SessionService
    {
        private const string LoggedKey = "isLogged";
        private const string UserKey = "currentUser";

        public bool IsLogged => Preferences.Default.Get(LoggedKey, false);
        
        public string getCurrentSessionUsername()
        {
            return Preferences.Default.Get<string?>(UserKey, null); ;
        }

        public void Login(string username)
        {
            Preferences.Default.Set(LoggedKey, true);
            Preferences.Default.Set(UserKey, username);
        }

        public void Logout()
        {
            Preferences.Default.Remove(LoggedKey);
            Preferences.Default.Remove(UserKey);
        }
    }
}
