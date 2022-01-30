using AutoMapper;
using Portfolio_Fatnis.Interfaces.Respositories;
using Portfolio_Fatnis.Interfaces.Services;
using Portfolio_Fatnis.Models;
using Portfolio_Fatnis.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<Project> Create(ProjectViewModel model)
        {
            Project project = _mapper.Map<Project>(model);
            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.Img.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                project.Image = pictureBytes;
            }
            var result = await _projectRepository.Create(project);

            return result;
        }

        public async Task<bool> Update(ProjectViewModel model)
        {

            Project project =new Project();
            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.Img.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                project.Image = pictureBytes;
            }

            var result = await _projectRepository.Update(project);

        
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            Project product = await _projectRepository.FindById(Id);
            if (product != null)
            {
                return await _projectRepository.Delete(product);
            }
            else
            {
                throw new ArgumentException("Cannot find product to delete", "Delete");
            }
        }

        public async Task<List<Project>> FindAll()
        {
            return await _projectRepository.FindAll();
        }

        public async Task<Project> FindById(int Id)
        {
            return await _projectRepository.FindById(Id);
        }

        public async Task<List<Project>> FindByCategory(int CategoryId)
        {
            return await _projectRepository.FindByCategory(CategoryId);
        }

        //public async Task<bool> IProjectService.Update(ProjectViewModel entity)
        //{
        //    return await _projectRepository.Update(entity);
        //}
    }
}
