namespace TP6ProgramacionMovil.Models
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Username { get; set; } = "";
        public string Rol { get; set; } = "";
        public string Token { get; set; } = "";
    }
}