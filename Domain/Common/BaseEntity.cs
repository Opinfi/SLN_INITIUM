namespace Domain.Common
{
    public class BaseEntity
    {
        //public long Id { get; set; }
        public bool Estado { get; set; }    
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string? IpRegistro { get; set; }
        public string? IpModificacion { get; set; }
        public string? IpAnulacion { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? UsuarioModificacion { get; set; }
        public string? UsuarioAnulacion { get; set; }
    }
}
