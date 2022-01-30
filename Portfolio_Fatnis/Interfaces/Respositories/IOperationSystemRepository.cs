using Portfolio_Fatnis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Interfaces.Respositories
{
    public interface IOperationSystemRepository
    {
        public Task<OperationSystem> Create(OperationSystem entity);
        public Task<bool> Update(OperationSystem entity);
        public Task<bool> Delete(int Id);
        public Task<bool> Save();
        public bool isExists(int Id);
        public List<OperationSystem> FindAll();
        public OperationSystem FindById(int Id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
