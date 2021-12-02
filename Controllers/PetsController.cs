using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        //** ENDPOINTS

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.Include(pet => pet.ownedBy);
        }

        // GET api/pets/:id
        [HttpGet("{id}")]
        public Pet GetById(int id)
        {
            return _context.Pets
            .Include(pet => pet.ownedBy)
            .SingleOrDefault(pet => pet.id == id);
        }

        //PUT /api/pets/:id, body must be JSON with all required fields
        //id = id of pet in DB
        //pet = pet JSON object

        [HttpPost]
        public IActionResult Create(Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }
            _context.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Create), new { id = pet.id }, pet);
        }

        //DEL /api/pets/:id

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
            if (pet == null)
            {
                //not found
                return NotFound(); //404
            }

            //delete the bread
            _context.Pets.Remove(pet);
            _context.SaveChanges();
            //respond with no content
            return NoContent(); //204
        }

                //PUT /api/pets/:id, body must be JSON with all required fields
        //id = id of pet in DB
        //pet = pet JSON object
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pet pet)
        {
            if (id != pet.id)
            {
                return BadRequest();
            }
            //Update in DB
            _context.Update(pet);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

