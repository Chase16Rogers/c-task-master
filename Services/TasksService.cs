using System;
using System.Collections.Generic;
using task_master_api.Models;
using task_master_api.Repositories;

namespace task_master_api.Services
{
    public class TasksService
{
      private readonly TasksRepository _repo;

    public TasksService(TasksRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Task> GetAll()
    {
      return _repo.GetAll();
    }

    internal Task GetOne(int id)
    {
      Task found = _repo.GetOne(id);
      if(found == null)
      {
          throw new Exception("BAD ID.");
      }
      return found;
    }

    internal Task Create(Task newTask)
    {
        int id = _repo.Create(newTask);
        newTask.id = id;
        return newTask;
    }

    internal Task Edit(int id, Task editTask)
    {
      Task found = GetOne(id);
      editTask.id = id;
      return _repo.Edit(editTask);
    }

    internal object Delete(int id)
    {
      Task found = GetOne(id);
      return _repo.Delete(id);
    }
  }
}