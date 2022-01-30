using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio_Fatnis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Interfaces.Services
{
    public interface IOperationSystemService
    {
        public Task<OperationSystem> Create(OperationSystem entity);
        public Task<bool> Update(OperationSystem entity);
        public Task<bool> Delete(int Id);
        public List<OperationSystem> FindAll();
        public OperationSystem FindById(int Id);
        public bool isExists(int id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
