using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CS_Lego.Models;
using CS_Lego.Services;
namespace CS_Lego.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BricksController : ControllerBase
    {
       private readonly BrickService _service;
       public BricksController(BrickService service)
       {
        _service = service;
       } 

       //Get
       [HttpGet]
       public ActionResult<IEnumerable<Brick>> Get()
       {
           try
           {
               return Ok(_service.Get());
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
       }

       //GetById
       [HttpGet("{Id}")]
       public ActionResult<Brick> Get(int Id)
       {
             try
           {
               return Ok(_service.Get(Id));
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
       }

        //Post
       [HttpPost]
       public ActionResult<Brick> Post([FromBody] Brick newBrick)
       {
             try
           {
               return Ok(_service.Create(newBrick));
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
       }

       //Put
        [HttpPut("{id}")]
        public ActionResult<Brick> Edit([FromBody] Brick newBrick, int id)
        {
              try
           {
               newBrick.Id = id;
               return Ok(_service.Edit(newBrick));
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Brick> Delete(int id)
        {
              try
           {
               return Ok(_service.Delete(id));
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
        }

    }
}