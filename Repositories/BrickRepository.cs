using System;
using System.Collections.Generic;
using System.Data;
using CS_Lego.Models;
using Dapper;

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
      string sql = "SELECT * FROM bricks";
      return _db.Query<Brick>(sql);
    }

    internal Brick GetById(int Id)
    {
       string sql = "SELECT * FROM bricks WHERE id = @Id";
       return _db.QueryFirstOrDefault<Brick>(sql, new { Id });
    }

    internal int Create(Brick newBrick)
    {
      string sql = @"
      INSERT INTO bricks
      (name, description)
      VALUES
      (@Name, @Description);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBrick);
    }

    internal Brick Edit(Brick original)
    {
      string sql = @"
      UPDATE bricks
      SET
        name = @Name,
        description = @Description
        WHERE id = @Id;
        SELECT * FROM bricks WHERE id = @Id;";
        return _db.QueryFirstOrDefault<Brick>(sql, original);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM bricks WHERE id = @Id";
      _db.Execute(sql, new {Id});
    }
  }
}