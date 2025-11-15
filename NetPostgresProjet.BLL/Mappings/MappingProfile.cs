using AutoMapper;
using NetPostgresProjet.BLL.DTOs;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mappings existants
            CreateMap<Patients, PatientDto>().ReverseMap();
            CreateMap<Employes, EmployeDto>().ReverseMap();
            CreateMap<Rendezvous, RendezvousDto>().ReverseMap();

            // Nouveaux mappings
            CreateMap<Chambres, ChamberDto>().ReverseMap();
            CreateMap<Dossierpatients, DossierPatientDto>().ReverseMap();
            CreateMap<Factures, FactureDto>().ReverseMap();
            CreateMap<Hospitalisations, HospitalisationDto>().ReverseMap();
            CreateMap<Ordonnances, OrdonnanceDto>().ReverseMap();
        }
    }
}
