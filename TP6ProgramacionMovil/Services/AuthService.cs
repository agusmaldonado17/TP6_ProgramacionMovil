using System.Net.Http.Headers;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthResponse? UsuarioActual { get; private set; }

        public bool EstaAutenticado => UsuarioActual != null;

        public bool EsAdmin => UsuarioActual?.Rol == "Admin";
        public bool EsVendedor => UsuarioActual?.Rol == "Vendedor";
        public bool EsCliente => UsuarioActual?.Rol == "Cliente";

        public event Action? OnAuthStateChanged;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AuthResponse?> LoginAsync(
            string username,
            string password)
        {
            var login = new LoginRequest
            {
                Username = username,
                Password = password
            };

            var response = await _http.PostAsJsonAsync(
                "api/Auth/Login",
                login
            );

            if (!response.IsSuccessStatusCode)
                return null;

            var auth = await response.Content
                .ReadFromJsonAsync<AuthResponse>();

            if (auth == null)
                return null;

            UsuarioActual = auth;

            await SecureStorage.Default.SetAsync(
                "auth_token",
                auth.Token
            );

            Preferences.Default.Set("auth_id", auth.Id);
            Preferences.Default.Set("auth_nombre", auth.Nombre);
            Preferences.Default.Set("auth_username", auth.Username);
            Preferences.Default.Set("auth_rol", auth.Rol);

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    auth.Token
                );

            OnAuthStateChanged?.Invoke();

            return auth;
        }

        public async Task<bool> RestaurarSesionAsync()
        {
            var token = await SecureStorage.Default
                .GetAsync("auth_token");

            if (string.IsNullOrWhiteSpace(token))
                return false;

            UsuarioActual = new AuthResponse
            {
                Id = Preferences.Default.Get("auth_id", 0),
                Nombre = Preferences.Default.Get("auth_nombre", ""),
                Username = Preferences.Default.Get("auth_username", ""),
                Rol = Preferences.Default.Get("auth_rol", ""),
                Token = token
            };

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );

            OnAuthStateChanged?.Invoke();

            return true;
        }

        public void Logout()
        {
            SecureStorage.Default.Remove("auth_token");

            Preferences.Default.Remove("auth_id");
            Preferences.Default.Remove("auth_nombre");
            Preferences.Default.Remove("auth_username");
            Preferences.Default.Remove("auth_rol");

            _http.DefaultRequestHeaders.Authorization = null;

            UsuarioActual = null;

            OnAuthStateChanged?.Invoke();
        }
    }
}