using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using task_master_api.Models;

namespace task_master_api.Repositories
{
  public class ListsRepository
  {
    public readonly IDbConnection _db;

    public ListsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal List GetOne(int id)
    {
      string sql = "SELECT * FROM lists WHERE id = @id;";
      return _db.QueryFirstOrDefault<List>(sql, new { id });
    }

    internal IEnumerable<List> GetListsByCreator(string id)
    {
      string sql = "SELECT * FROM lists WHERE creatorId = @id;";
      return _db.Query<List>(sql, new { id });
    }

    internal int Create(List newList)
    {
      string sql = @"
      INSERT INTO lists (name, creatorId) VALUES (@name, @creatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newList);
    }

    internal List Edit(List editList)
    {
      string sql = @"UPDATE lists SET name = @name
      WHERE id = @id;";
      _db.Execute(sql, editList);
      return editList;
    }

    internal object Delete(int id)
    {
      string sql = "DELETE FROM lists WHERE id = @id;";
      _db.Execute(sql, new { id });
      return "Deleted";
    }
  }
}