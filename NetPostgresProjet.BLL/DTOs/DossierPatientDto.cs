using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class DossierPatientDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string? GroupeSanguin { get; set; }
        public string? Allergies { get; set; }
        public string? AntecedentsMedicaux { get; set; }
        public string? TraitementsEnCours { get; set; }
        public string? NotesMedecin { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMiseAJour { get; set; }
    }
}
