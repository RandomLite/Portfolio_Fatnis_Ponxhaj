using Portfolio_Fatnis.Models;
using Portfolio_Fatnis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Interfaces.Services
{
    public interface IProjectService
    {
        public Task<Project> Create(ProjectViewModel entity);
        public Task<bool> Update(ProjectViewModel entity);
        public Task<bool> Delete(int Id);
        public Task<List<Project>> FindAll();
        public Task<Project> FindById(int Id);
        public Task<List<Project>> FindByCategory(int CategoryId);
    }
}
