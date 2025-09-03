using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PRUEBA_TECNICA_IMOVS.Api.Data.Repositories;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Api.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Api.Services.Contracts;


namespace PRUEBA_TECNICA_IMOVS.Api.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly IMapper _mapper;


        public ProductService(IGenericRepository<Product> repo, IMapper mapper)
        {
            _repo = repo; _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var list = await _repo.Query().OrderBy(p => p.Name).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(list);
        }


        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ProductDto>(entity);
        }


        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repo.AddAsync(entity);
            return _mapper.Map<ProductDto>(entity);
        }


        public async Task<ProductDto> UpdateAsync(int id, ProductDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;


            entity.Sku = dto.Sku;
            entity.Name = dto.Name;
            entity.UnitPrice = dto.UnitPrice;
            entity.IsActive = dto.IsActive;


            _repo.Update(entity);
            await _repo.SaveChangesAsync();
            return _mapper.Map<ProductDto>(entity);
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return;
            _repo.Remove(entity);
            await _repo.SaveChangesAsync();
        }
    }
}