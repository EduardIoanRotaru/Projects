using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DTO;

namespace ToDoAPI.Controllers
{
    public class ProjectsController : RootController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _unitOfWork.ProjectRepository.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<ProjectDto>>(projects));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id) 
        {
            var project = await _unitOfWork.ProjectRepository.GetProjectWithTasks(id);

            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, ProjectDto projectDto) 
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(projectId);

            if(project == null) return NotFound();

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;
            project.Completed = projectDto.Completed;

            if(await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Couldn't edit the project");
        }

        [HttpPut("completeProject/{projectId}/{completed}")]
        public async Task<IActionResult> CompleteProject(int projectId, bool completed)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(projectId);
            
            if(project == null) return NotFound();

            project.Completed = completed;

            if(await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Couldn't mark your project as complete");
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId) 
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(projectId);

            if(project == null) return NotFound();

            _unitOfWork.ProjectRepository.DeleteAsync(project);

            if(await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Couldn't delete your project");
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);

            _unitOfWork.ProjectRepository.AddAsync(project);

            if(await _unitOfWork.Complete())
                return CreatedAtAction(
                    nameof(GetProjectById),
                    new { id = project.Id },
                    new ProjectDto
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Description = project.Description,
                        Completed = project.Completed
                    }
                );

            return BadRequest("Couldn't add your project");
        }
    }
}