using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.Infrastructure;
using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;

namespace FlowerHotel.Controllers
{
    [Authorize]
    public class PlantController : ApiController
    {
        private IPlantService PlantService
        {
            get
            {
                return new ServiceCreator().CreatePlantService("DefaultConnection");
            }
        }
        // GET: api/Plant
        public IHttpActionResult Get()
        {
            return Ok(PlantService.GetAll());
        }

        // GET: api/Plant/5
        public IHttpActionResult Get(int id)
        {
            return Ok(PlantService.Get(id));
        }

        // POST: api/Plant
        public IHttpActionResult Post(PlantModel plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            PlantDTO plantDTO = new PlantDTO();
            plantDTO.Name = plant.Name;
            //plantDTO.ApplicationUserId = User.Id
            PlantService.Create(plantDTO);
            return Ok();
        }

        // PUT: api/Hotel/5
        public IHttpActionResult Put(PlantModel plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            PlantDTO plantDTO = new PlantDTO();
            plantDTO.Id = plant.Id;
            plantDTO.Name = plant.Name;
            PlantService.Update(plantDTO);
            return Ok();
        }

        // DELETE: api/Plant/5
        public IHttpActionResult Delete(int id)
        {
            PlantService.Delete(id);
            return Ok();
        }
    }
}
