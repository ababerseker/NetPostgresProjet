using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class RendezvousDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedecinId { get; set; }
        public DateTime DateRendezVous { get; set; }
        public string? Motif { get; set; }
        public string? Statut { get; set; }
    }
}
