using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class RendezvousDto
    {
        public int Idrdv { get; set; }
        public int? Patientid { get; set; }
        public int? Medecinid { get; set; }
        public DateTime? Daterdv { get; set; }
        public string? Heurerdv { get; set; }
        public string? Statut { get; set; }
        public string? Motif { get; set; }
    }
}
