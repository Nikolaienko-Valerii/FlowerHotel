﻿using FlowerHotel.DAL.EF;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}