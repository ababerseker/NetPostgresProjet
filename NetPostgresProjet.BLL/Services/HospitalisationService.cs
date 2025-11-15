using AutoMapper;
using NetPostgresProjet.BLL.DTOs;
using NetPostgresProjet.BLL.Interfaces;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Services
{
    public class HospitalisationService : IHospitalisationService
    {
        private readonly IHospitalisationRepository _hospitalisationRepository;
        private readonly IMapper _mapper;

        public HospitalisationService(IHospitalisationRepository hospitalisationRepository, IMapper mapper)
        {
            _hospitalisationRepository = hospitalisationRepository;
            _mapper = mapper;
        }

        public async Task<HospitalisationDto> GetByIdAsync(int id)
        {
            var hospitalisation = await _hospitalisationRepository.GetByIdAsync(id);
            return _mapper.Map<HospitalisationDto>(hospitalisation);
        }

        public async Task<IEnumerable<HospitalisationDto>> GetAllAsync()
        {
            var hospitalisations = await _hospitalisationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HospitalisationDto>>(hospitalisations);
        }

        public async Task<IEnumerable<HospitalisationDto>> GetByPatientIdAsync(int patientId)
        {
            var hospitalisations = await _hospitalisationRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<HospitalisationDto>>(hospitalisations);
        }

        public async Task<IEnumerable<HospitalisationDto>> GetHospitalisationsEnCoursAsync()
        {
            var hospitalisations = await _hospitalisationRepository.GetHospitalisationsEnCoursAsync();
            return _mapper.Map<IEnumerable<HospitalisationDto>>(hospitalisations);
        }

        public async Task<HospitalisationDto> CreateAsync(HospitalisationDto hospitalisationDto)
        {
            var hospitalisation = _mapper.Map<Hospitalisations>(hospitalisationDto);
            var created = await _hospitalisationRepository.AddAsync(hospitalisation);
            return _mapper.Map<HospitalisationDto>(created);
        }

        public async Task<HospitalisationDto> UpdateAsync(int id, HospitalisationDto hospitalisationDto)
        {
            var existing = await _hospitalisationRepository.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("Hospitalisation non trouvée");

            _mapper.Map(hospitalisationDto, existing);
            var updated = await _hospitalisationRepository.UpdateAsync(existing);
            return _mapper.Map<HospitalisationDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _hospitalisationRepository.DeleteAsync(id);
        }
    }
}

