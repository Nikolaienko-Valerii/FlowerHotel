using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IResourceService : IDisposable
    {
        Task Create(ResourceDTO resourceDto);
        Task Update(ResourceDTO resourceDto);
        Task Delete(int resourceId);
        IEnumerable<ResourceDTO> GetAll();
        ResourceDTO Get(int resourceId);
    }
}
