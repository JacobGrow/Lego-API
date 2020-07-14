using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CS_Lego.Models;
using CS_Lego.Services;




namespace CS_Lego.Controllers
{
    public class LegoKitsController
    {
        [ApiController]
        [Route("api/[controller]")]
    
        public class KitsController : ControllerBase
        {
            private readonly KitService _service;
            
            public KitsController(KitService service)
            {
                _service = service;
            }

            //Get
            [HttpGet]
            public ActionResult<IEnumerable<Kit>> Get()
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
            [HttpGet("{kitId}")]
            public ActionResult<Kit> GetAction(int kitId)
            {
                try
                {
                    return Ok(_service.Get(kitId));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            //Post
            [HttpPost]
            public ActionResult<Kit> Post([FromBody] Kit newKit)
            {
                try
                {
                    return Ok(_service.Create(newKit));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPut("{id}")]
            public ActionResult<Kit> Edit([FromBody] Kit newKit, int id)
            {
                try
                {
                    newKit.Id = id;
                    return Ok(_service.Edit(newKit));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id}")]
            public ActionResult<Kit> Delete(int id)
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
}