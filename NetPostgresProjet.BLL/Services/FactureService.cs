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
    public class FactureService : IFactureService
    {
        private readonly IFactureRepository _factureRepository;
        private readonly IMapper _mapper;

        public FactureService(IFactureRepository factureRepository, IMapper mapper)
        {
            _factureRepository = factureRepository;
            _mapper = mapper;
        }

        public async Task<FactureDto> GetByIdAsync(int id)
        {
            var facture = await _factureRepository.GetByIdAsync(id);
            return _mapper.Map<FactureDto>(facture);
        }

        public async Task<IEnumerable<FactureDto>> GetAllAsync()
        {
            var factures = await _factureRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FactureDto>>(factures);
        }

        public async Task<IEnumerable<FactureDto>> GetByPatientIdAsync(int patientId)
        {
            var factures = await _factureRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<FactureDto>>(factures);
        }

        public async Task<IEnumerable<FactureDto>> GetFacturesEnAttenteAsync()
        {
            var factures = await _factureRepository.GetFacturesEnAttenteAsync();
            return _mapper.Map<IEnumerable<FactureDto>>(factures);
        }

        public async Task<FactureDto> CreateAsync(FactureDto factureDto)
        {
            var facture = _mapper.Map<Factures>(factureDto);
            var created = await _factureRepository.AddAsync(facture);
            return _mapper.Map<FactureDto>(created);
        }

        public async Task<FactureDto> UpdateAsync(int id, FactureDto factureDto)
        {
            var existing = await _factureRepository.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("Facture non trouvée");

            _mapper.Map(factureDto, existing);
            var updated = await _factureRepository.UpdateAsync(existing);
            return _mapper.Map<FactureDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _factureRepository.DeleteAsync(id);
        }
    }
}

