using cooptutorial.Database;
using cooptutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;


namespace Cooptutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devicesController : ControllerBase
    {
        //Variable
        private readonly DataDbContext _dbContext;

        //Contructure Method
        public devicesController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // get post put delete

        //  Async Await
        [HttpGet]
        public async Task<ActionResult<List<devices>>> getdevices()
        {
            var devices = await _dbContext.devices.ToListAsync();
            if (devices.Count == 0)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<devices>> getdevices(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        //get by ManufacturerId
        [HttpGet("{ManufacturerId}")]
        public async Task<ActionResult<devices>> getdevice(int Manufacturer_id)
        {
            var devices = await _dbContext.devices.FindAsync(Manufacturer_id);
            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }

        // Post Method
        [HttpPost]
        public async Task<ActionResult<devices>> postdevices(devices devices)
        {
            try
            {
                _dbContext.devices.Add(devices);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return Ok(devices);
        }

        //Put
        [HttpPut]
        public async Task<ActionResult<devices>> puttdevices(int id, devices newdevices)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            // Edit 
            devices.Id = newdevices.Id;
            devices.Title = newdevices.Title;

            await _dbContext.SaveChangesAsync();

            // Save

            await _dbContext.SaveChangesAsync();



            return Ok();
        }

        //Delete


        [HttpDelete]
        public async Task<ActionResult<devices>> deletedevices(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            //Remove
            _dbContext.devices.Remove(devices);

            //Save
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


    }
}