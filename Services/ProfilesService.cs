using System;
using task_master_api.Models;
using task_master_api.Repositories;

namespace task_master_api.Services
{
  public class ProfilesService
  {
      private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetOne(userInfo.id);
      if(profile == null){
          return _repo.Create(userInfo);
      }
      return profile;
    }
  }
}