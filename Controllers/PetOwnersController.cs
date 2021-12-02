using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }


        // GET /api/petowners
        [HttpGet]
        public IEnumerable<PetOwner> GetAll()
        {
            Console.WriteLine("in /api/petowners GET all");
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
            public ActionResult<PetOwner> GetById(int id)
        {
            Console.WriteLine("in /api/petowners/:id GET");

            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            //catch
            if (petOwner == null)
            {
                return NotFound();
            }

            return petOwner;
        }


        [HttpPost]
        public IActionResult Create(PetOwner newPetOwner)
        {
            _context.PetOwners.Add(newPetOwner);

            _context.SaveChanges();

            return CreatedAtAction(nameof(Create), new { id = newPetOwner.id }, newPetOwner);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("deleting with id: " + id);
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            //if no petowner exist, return error
            if (petOwner is null)
            {
                return NotFound();
            }

            //deleting and saving in db
            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();

            return NoContent(); //204
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, PetOwner petOwner)
        {
            Console.WriteLine("in PUT");

            if (id != petOwner.id)
            {
                return BadRequest();
            }

            //update in DB and save
            _context.PetOwners.Update(petOwner);
            _context.SaveChanges();

            return NoContent(); //204
        }

    }
}




