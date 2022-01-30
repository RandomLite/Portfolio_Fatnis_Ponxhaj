using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio_Fatnis.Data;
using Portfolio_Fatnis.Interfaces.Respositories;
using Portfolio_Fatnis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Respositories
{
    public class OperationSystemRepository : IOperationSystemRepository
    {
        private readonly PortfolioContext _context;

        public OperationSystemRepository(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<OperationSystem> Create(OperationSystem operating)
        {
            _context.OperationSystemCX.Add(operating);
            await Save();

            //_context.Add(operating);
            //await _context.SaveChangesAsync();

            return operating;
        }
        public async Task<bool> Delete(int id)
        {
            OperationSystem operating = FindById(id);
            if (operating != null)
            {
                _context.OperationSystemCX.Remove(operating);
                return await Save();
            }
            else
            {
                return false;
            }

        }

        public List<OperationSystem> FindAll()
        {
            return _context.OperationSystemCX.ToList();

        }

        public OperationSystem FindById(int id)
        {
            return _context.OperationSystemCX.Find(id);
        }

        public bool isExists(int id)
        {
            return _context.OperationSystemCX.Any(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            List<SelectListItem> operationSystems = await _context.OperationSystemCX.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
            return operationSystems;
        }

        public async Task<bool> Update(OperationSystem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
