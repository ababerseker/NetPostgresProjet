using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class PatientDto
    {
        public int Idpatient { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? Datenaissance { get; set; }
        public string? Sexe { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
