namespace Application.Features.ClienteFeatures.Queries
{
    public class ClienteDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public string? Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
