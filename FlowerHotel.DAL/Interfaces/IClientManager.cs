using FlowerHotel.DAL.Entities;
using System;

namespace FlowerHotel.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
