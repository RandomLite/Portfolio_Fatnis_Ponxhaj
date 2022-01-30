using Portfolio_Fatnis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Interfaces.Respositories
{
    public interface IProjectRepository
    {
        public Task<Project> Create(Project Entity);
        public Task<bool> Update(Project Entity);
        public Task<bool> Delete(Project Entity);
        public Task<bool> Save();
        public bool isExists(int Id);
        public Task<List<Project>> FindAll();
        public Task<Project> FindById(int Id);
        public Task<List<Project>> FindByCategory(int CategoryId);
    }
}

