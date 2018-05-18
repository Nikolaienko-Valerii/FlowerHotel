using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
