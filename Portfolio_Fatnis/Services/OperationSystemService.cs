using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio_Fatnis.Interfaces.Respositories;
using Portfolio_Fatnis.Interfaces.Services;
using Portfolio_Fatnis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Services
{
    public class OperationSystemService : IOperationSystemService
    {
        private readonly IOperationSystemRepository _operationSystemRepository;


        public OperationSystemService(IOperationSystemRepository operationSystemRepository)
        {
            _operationSystemRepository = operationSystemRepository;
        }

        public async Task<OperationSystem> Create(OperationSystem entity)
        {

            return await _operationSystemRepository.Create(entity);
        }

        public OperationSystem FindById(int Id)
        {
            return _operationSystemRepository.FindById(Id);
        }
        public List<OperationSystem> FindAll()
        {
            return _operationSystemRepository.FindAll();
        }
        public async Task<bool> Update(OperationSystem entity)
        {
            return await _operationSystemRepository.Update(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _operationSystemRepository.Delete(id);
        }

        public bool isExists(int id)
        {
            return _operationSystemRepository.isExists(id);
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            return await _operationSystemRepository.SelectListItems();
        }
}
}
