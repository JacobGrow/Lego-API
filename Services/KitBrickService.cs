using System;
using System.Collections.Generic;
using CS_Lego.Models;
using CS_Lego.Repositories;

namespace CS_Lego.Services
{
  public class KitBrickService
  {
    private readonly KitBrickRepository _repo;
    public KitBrickService(KitBrickRepository repo)
    {
      _repo = repo;
    }
  }
}