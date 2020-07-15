using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CS_Lego.Models;
using CS_Lego.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CS_Lego.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
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
            public ActionResult<Kit> Get(int kitId)
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
            [Authorize] 
            public ActionResult<Kit> Post([FromBody] Kit newData)
            {
                try
            {
                string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // req.userInfo.email
                newData.Creator = UserEmail;
                return Ok(_service.Create(newData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            }

            [HttpPut("{id}")]
            [Authorize]
            public ActionResult<Kit> Edit([FromBody] Kit newKit, int id)
            {
                try
                {
                    string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // req.userInfo.email
                    newKit.Id = id;
                    return Ok(_service.Edit(newKit));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id}")]
            [Authorize]
            public ActionResult<Kit> Delete(int id)
            {
                try
                {
                    string UserEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; // req.userInfo.email
                    return Ok(_service.Delete(id, UserEmail));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
