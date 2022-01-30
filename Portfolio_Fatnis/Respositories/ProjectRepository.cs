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
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioContext _context;

        public ProjectRepository(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<Project> Create(Project entity)
        {
            await _context.ProjectCX.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<bool> Delete(Project entity)
        {
            _context.ProjectCX.Remove(entity);
            return await Save();
        }

        public async Task<List<Project>> FindAll()
        {
            return await _context.ProjectCX.Include(x => x.OperationSystem).ToListAsync();
        }

        public async Task<List<Project>> FindByCategory(int OperationSystemId)
        {
            return await _context.ProjectCX.Where(x => x.OperationSystemId == OperationSystemId).ToListAsync();
        }

        public async Task<Project> FindById(int Id)
        {
            return await _context.ProjectCX.Include(x => x.OperationSystem).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public bool isExists(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Project entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
