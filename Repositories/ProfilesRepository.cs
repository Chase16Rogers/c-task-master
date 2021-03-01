using System;
using System.Data;
using Dapper;
using task_master_api.Models;

namespace task_master_api.Repositories
{
  public class ProfilesRepository
  {
    public readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetOne(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = "INSERT INTO profiles (id, name, email, picture) VALUES (@id, @name, @email, @picture);";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}