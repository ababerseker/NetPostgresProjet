using AutoMapper;
using NetPostgresProjet.BLL.DTOs;
using NetPostgresProjet.BLL.Interfaces;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Services
{
    public class DossierPatientService : IDossierPatientService
    {
        private readonly IDossierPatientRepository _dossierPatientRepository;
        private readonly IMapper _mapper;

        public DossierPatientService(IDossierPatientRepository dossierPatientRepository, IMapper mapper)
        {
            _dossierPatientRepository = dossierPatientRepository;
            _mapper = mapper;
        }

        public async Task<DossierPatientDto> GetByIdAsync(int id)
        {
            var dossier = await _dossierPatientRepository.GetByIdAsync(id);
            return _mapper.Map<DossierPatientDto>(dossier);
        }

        public async Task<DossierPatientDto> GetByPatientIdAsync(int patientId)
        {
            var dossier = await _dossierPatientRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<DossierPatientDto>(dossier);
        }

        public async Task<DossierPatientDto> CreateAsync(DossierPatientDto dossierDto)
        {
            var dossier = _mapper.Map<Dossierpatients>(dossierDto);
            var created = await _dossierPatientRepository.AddAsync(dossier);
            return _mapper.Map<DossierPatientDto>(created);
        }

        public async Task<DossierPatientDto> UpdateAsync(int id, DossierPatientDto dossierDto)
        {
            var existing = await _dossierPatientRepository.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("Dossier patient non trouvé");

            _mapper.Map(dossierDto, existing);
            var updated = await _dossierPatientRepository.UpdateAsync(existing);
            return _mapper.Map<DossierPatientDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _dossierPatientRepository.DeleteAsync(id);
        }

        public async Task<bool> PatientHasDossierAsync(int patientId)
        {
            return await _dossierPatientRepository.PatientHasDossierAsync(patientId);
        }
    }
}

