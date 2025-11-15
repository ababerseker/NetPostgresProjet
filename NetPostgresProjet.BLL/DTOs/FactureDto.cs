using System;

namespace NetPostgresProjet.BLL.DTOs
{
    public class FactureDto
    {
        public int Id { get; set; }
        public string? NumeroFacture { get; set; }
        public int PatientId { get; set; }
        public DateTime DateEmission { get; set; }
        public DateTime? DatePaiement { get; set; }
        public decimal MontantTotal { get; set; }
        public decimal MontantPaye { get; set; }
        public string? Statut { get; set; }
        public string? ModePaiement { get; set; }
    }
}
