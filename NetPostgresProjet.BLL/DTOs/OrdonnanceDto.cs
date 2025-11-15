using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class OrdonnanceDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedecinId { get; set; }
        public DateTime DatePrescription { get; set; }
        public string? Medicaments { get; set; }
        public string? Posologie { get; set; }
        public string? Instructions { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool EstRenouvelable { get; set; }
    }
}
