namespace NetPostgresProjet.BLL.DTOs
{
    public class ChambresDto
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Type { get; set; }
        public int Etage { get; set; }
        public bool Disponible { get; set; }
        public decimal PrixParJour { get; set; }
    }
}
