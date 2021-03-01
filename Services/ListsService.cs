using System;
using System.Collections.Generic;
using task_master_api.Models;
using task_master_api.Repositories;

namespace task_master_api.Services
{
  public class ListsService
  {
      private readonly ListsRepository _repo;

    public ListsService(ListsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<List> GetListsByCreator(string id)
    {
      return _repo.GetListsByCreator(id);
    }
    
    internal List GetOne(int id)
    {
      List found = _repo.GetOne(id);
      if(found == null)
      {
          throw new Exception("BAD ID.");
      }
      return found;
    }

    internal List Create(List newList)
    {
        int id = _repo.Create(newList);
        newList.id = id;
        return newList;
    }

    internal List Edit(int id, List editList)
    {
      List found = GetOne(id);
      editList.id = id;
      return _repo.Edit(editList);
    }

    internal object Delete(int id)
    {
      List found = GetOne(id);
      return _repo.Delete(id);
    }
  }
}