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
    public class ChambresService : IChambresService
    {
        private readonly IChambresRepository _chambresRepository;
        private readonly IMapper _mapper;

        public ChambresService(IChambresRepository chambresRepository, IMapper mapper)
        {
            _chambresRepository = chambresRepository;
            _mapper = mapper;
        }

        public async Task<ChambresDto> GetByIdAsync(int id)
        {
            var chambres = await _chambresRepository.GetByIdAsync(id);
            return _mapper.Map<ChambresDto>(chambres);
        }

        public async Task<IEnumerable<ChambresDto>> GetAllAsync()
        {
            var chambres = await _chambresRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ChambresDto>>(chambres);
        }

        public async Task<IEnumerable<ChambresDto>> GetChambresDisponiblesAsync()
        {
            var chambres = await _chambresRepository.GetChambresDisponiblesAsync();
            return _mapper.Map<IEnumerable<ChambresDto>>(chambres);
        }

        public async Task<ChambresDto> CreateAsync(ChambresDto chambresDto)
        {
            var chambres = _mapper.Map<Chambres>(chambresDto);
            var created = await _chambresRepository.AddAsync(chambres);
            return _mapper.Map<ChambresDto>(created);
        }

        public async Task<ChambresDto> UpdateAsync(int id, ChambresDto chambresDto)
        {
            var existing = await _chambresRepository.GetByIdAsync(id);
            if (existing == null) throw new ArgumentException("Chambre non trouvée");

            _mapper.Map(chambresDto, existing);
            var updated = await _chambresRepository.UpdateAsync(existing);
            return _mapper.Map<ChambresDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _chambresRepository.DeleteAsync(id);
        }

        public async Task<bool> NumeroExistsAsync(string numero, int? excludeId = null)
        {
            return await _chambresRepository.NumeroExistsAsync(numero, excludeId);
        }
    }
}

