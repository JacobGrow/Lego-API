using System;
using System.Collections.Generic;
using System.Data;
using CS_Lego.Models;
using Dapper;

namespace CS_Lego.Repositories
{
  public class KitRepository
{
  private readonly IDbConnection _db;
  public KitRepository(IDbConnection db)
  {
      _db = db;
  }

  
    internal IEnumerable<Kit> Get()
    {
      string sql = "SELECT * FROM kits";
      return _db.Query<Kit>(sql);
    }

    internal Kit GetById(int kitId)
    {
      string sql = "SELECT * FROM kits WHERE id = @kitId";
      return _db.QueryFirstOrDefault<Kit>(sql, new { kitId });
    }

    internal int Create(Kit newKit)
    {
     string sql = @"
     INSERT INTO kits
     (description, name, price)
     VALUES
     (@Description, @Name, @Price);
     SELECT LAST_INSERT_ID();";
     return _db.ExecuteScalar<int>(sql, newKit);
    }

    internal Kit Edit(Kit original)
    {
     string sql =@"
     UPDATE kits
     SET
        name = @Name,
        description = @Description,
        price = @Price
    WHERE id = @id;
    SELECT * FROM kits WHERE id = @Id;";
    return _db.QueryFirstOrDefault<Kit>(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM kits WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}