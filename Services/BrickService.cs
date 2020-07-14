using System;
using System.Collections.Generic;
using CS_Lego.Models;
using CS_Lego.Repositories;

namespace CS_Lego.Services
{
  public class BrickService
  {
      private readonly BrickRepository _repo;
      public BrickService(BrickRepository repo)
      {
          _repo = repo;
      }
    public IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }
    internal Brick Get(int Id)
    {
      Brick exists = _repo.GetById(Id);
      if (exists == null){ throw new Exception("Invalid Brick my dude"); }
      return exists;
    }

    internal Brick Create(Brick newBrick)
    {
      int id = _repo.Create(newBrick);
      newBrick.Id = id;
      return newBrick;
    }

    public Brick Edit(Brick editBrick)
    {
      Brick original = Get(editBrick.Id);
      original.Name = editBrick.Name.Length > 0 ? editBrick.Name : original.Name;
      original.Description = editBrick.Description.Length > 0 ? editBrick.Description : original.Description;
      return (Brick)_repo.Edit(original);
      }

    internal Brick Delete(int id)
    {
      Brick exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    }
  }
