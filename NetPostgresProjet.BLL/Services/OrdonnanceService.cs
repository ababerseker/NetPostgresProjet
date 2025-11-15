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
    public class OrdonnanceService : IOrdonnanceService
    {
        private readonly IOrdonnanceRepository _ordonnanceRepository;
        private readonly IMapper _mapper;

        public OrdonnanceService(IOrdonnanceRepository ordonnanceRepository, IMapper mapper)
        {
            _ordonnanceRepository = ordonnanceRepository;
            _mapper = mapper;
        }

        public async Task<OrdonnanceDto> GetByIdAsync(int id)
        {
            var ordonnance = await _ordonnanceRepository.GetByIdAsync(id);
            return _mapper.Map<OrdonnanceDto>(ordonnance);
        }

        public async Task<IEnumerable<OrdonnanceDto>> GetAllAsync()
        {
            var ordonnances = await _ordonnanceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrdonnanceDto>>(ordonnances);
        }

        public async Task<IEnumerable<OrdonnanceDto>> GetByPatientIdAsync(int patientId)
        {
            var ordonnances = await _ordonnanceRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<OrdonnanceDto>>(ordonnances);
        }

        public async Task<IEnumerable<OrdonnanceDto>> GetByMedecinIdAsync(int medecinId)
        {
            var ordonnances = await _ordonnanceRepository.GetByMedecinIdAsync(medecinId);
            return _mapper.Map<IEnumerable<OrdonnanceDto>>(ordonnances);
        }

        public async Task<OrdonnanceDto> CreateAsync(OrdonnanceDto ordonnanceDto)
        {
            var ordonnance = _mapper.Map<Ordonnances>(ordonnanceDto);
            var created = await _ordonnanceRepository.AddAsync(ordonnance);
            return _mapper.Map<OrdonnanceDto>(created);
        }

        public async Task<OrdonnanceDto> UpdateAsync(int id, OrdonnanceDto ordonnanceDto)
        {
            var existing = await _ordonnanceRepository.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("Ordonnance non trouvée");

            _mapper.Map(ordonnanceDto, existing);
            var updated = await _ordonnanceRepository.UpdateAsync(existing);
            return _mapper.Map<OrdonnanceDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _ordonnanceRepository.DeleteAsync(id);
        }
    }
}

