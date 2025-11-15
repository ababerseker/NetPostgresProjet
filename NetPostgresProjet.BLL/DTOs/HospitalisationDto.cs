using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class HospitalisationDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ChamberId { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime? DateSortie { get; set; }
        public string? MotifAdmission { get; set; }
        public string? Diagnostic { get; set; }
        public string? Statut { get; set; }
        public string? NotesInfirmier { get; set; }
    }
}
