using cooptutorial.Database;
using cooptutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace cooptutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class menufacturersController : ControllerBase
    {
        //Variable
        private readonly DataDbContext _dbContext;

        //Contructure Method
        public menufacturersController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // get post put delete

        //  Async Await
        [HttpGet]
        public async Task<ActionResult<List<manufacturers>>> getManufacturers()
        {
            var manufacturers = await _dbContext.manufacturers.ToListAsync();
            if (manufacturers.Count == 0)
            {
                return NotFound();
            }
            return Ok(manufacturers);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<manufacturers>> getManufacturer(int id)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return Ok(manufacturer);
        }


        // Post Method
        [HttpPost]
        public async Task<ActionResult<manufacturers>> postManufacturer(manufacturers manufacturers)
        {
            try
            {
                _dbContext.manufacturers.Add(manufacturers);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return Ok(manufacturers);
        }

        //Put
        [HttpPut]
        public async Task<ActionResult<manufacturers>> puttManufacturer(int id, manufacturers newmanufacturer)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            // Edit 
            manufacturer.Id = newmanufacturer.Id;
            manufacturer.Title = newmanufacturer.Title;

            await _dbContext.SaveChangesAsync();

            // Save

            await _dbContext.SaveChangesAsync();



            return Ok();
        }

        //Delete


        [HttpDelete]
        public async Task<ActionResult<manufacturers>> deleteManufacturer(int id)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            //Remove
            _dbContext.manufacturers.Remove(manufacturer);

            //Save
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


    }
}
