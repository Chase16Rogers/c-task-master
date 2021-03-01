using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using task_master_api.Models;

namespace task_master_api.Repositories
{
  public class TasksRepository
  {
    public readonly IDbConnection _db;

    public TasksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Task> GetAll()
    {
      string sql = "SELECT * FROM tasks;";
      return _db.Query<Task>(sql);
    }

    internal Task GetOne(int id)
    {
      string sql = "SELECT * FROM tasks WHERE id = @id;";
      return _db.QueryFirstOrDefault<Task>(sql, new { id });
    }

    internal int Create(Task newTask)
    {
      string sql = @"
      INSERT INTO tasks (task, listId, creatorId, done) VALUES (@task, @listId, @creatorId, @done);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newTask);
    }

    internal Task Edit(Task editTask)
    {
      string sql = @"UPDATE tasks SET task = @task, done = @done
      WHERE id = @id;";
      _db.Execute(sql, editTask);
      return editTask;
    }

    internal object Delete(int id)
    {
      string sql = "DELETE FROM tasks WHERE id = @id;";
      _db.Execute(sql, new { id });
      return "Deleted";
    }
  }
}