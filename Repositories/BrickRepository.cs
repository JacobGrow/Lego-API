using System;
using System.Collections.Generic;
using System.Data;
using CS_Lego.Models;

namespace CS_Lego.Repositories
{
    public class BrickRepository
    {
        private readonly IDbConnection _db;
        public BrickRepository(IDbConnection db)
        {
            _db = db;
        }

    internal IEnumerable<Brick> Get()
    {
      throw new NotImplementedException();
    }

    internal Brick GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal int Create(Brick newBrick)
    {
      throw new NotImplementedException();
    }

    internal object Edit(Brick original)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}