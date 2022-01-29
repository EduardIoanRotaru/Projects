using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DTO;

namespace ToDoAPI.Controllers
{
    public class TaskController : RootController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _unitOfWork.TaskRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<TaskDto>>(tasks));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id) 
        {
            var task = await _unitOfWork.TaskRepository.GetTasksWithComments(id);

            return Ok(_mapper.Map<TaskDto>(task));
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskDto taskDto) 
        {
            var task = _mapper.Map<TaskDto, Core.Entities.Task>(taskDto);

            _unitOfWork.TaskRepository.AddAsync(task);

            if (await _unitOfWork.Complete()) 
                return CreatedAtAction(
                    nameof(GetTaskById),
                    new { id = task.Id },
                    new TaskDto {
                        Id = task.Id,
                        Name = task.Name,
                        DateToComplete = task.DateToComplete
                    });

            return BadRequest("Couldn't save your task");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskDto taskDto) 
        {
            var taskInDatabase = await _unitOfWork.TaskRepository.GetByIdAsync(taskDto.Id);

            if(taskInDatabase == null) return NotFound();

            taskInDatabase.Name = taskDto.Name;
            taskInDatabase.DateToComplete = taskDto.DateToComplete;
            taskInDatabase.Label = taskDto.Label;
            taskInDatabase.Completed = taskDto.Completed;

            _unitOfWork.TaskRepository.UpdateAsync(taskInDatabase);
            
            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Couldn't update your task");
        }
        
        [HttpPost("addTaskToProject/{taskId}/{projectId}")]
        public async Task<IActionResult> AddTaskToProject(int taskId, int projectId) 
        {
            var taskInDatabase = await _unitOfWork.TaskRepository.GetByIdAsync(taskId);
            var projectInDatabase = await _unitOfWork.ProjectRepository.GetByIdAsync(projectId);

            if(taskInDatabase == null || projectInDatabase == null) return NotFound();

            taskInDatabase.ProjectId = projectId;
            projectInDatabase.Completed = false;

            _unitOfWork.TaskRepository.UpdateAsync(taskInDatabase);

            if(await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Couldn't add task to project");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var taskInDatabase = await _unitOfWork.TaskRepository.GetByIdAsync(id);
            _unitOfWork.TaskRepository.DeleteAsync(taskInDatabase);

            if(await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Task not deleted");
        }

        [HttpGet("getAllTasksOrderedByDate")]
        public async Task<IActionResult> GetAllTasksOrderedByDate() 
        {
            var tasks = _mapper.Map<IReadOnlyList<TaskDto>>(
                await _unitOfWork.UpcomingTasksRepository.GetAllOrderedByDate()
            );

            return Ok(tasks);   
        }

        [HttpGet("getAllTasksOrderedByDateAndNotcompleted")]
        public async Task<IActionResult> GetAllTasksOrderedByDateAndNotcompleted() 
        {
            var tasks = _mapper.Map<IReadOnlyList<TaskDto>>(
                await _unitOfWork.UpcomingTasksRepository.GetAllOrderedByDateAndNotcompleted()
            );

            return Ok(tasks);
        }

        [HttpGet("getAllTasksOrderedByLabel")]
        public async Task<IActionResult> GetAllTasksOrderedByLabel() 
        {
            var tasks = _mapper.Map<IReadOnlyList<TaskDto>>(
                await _unitOfWork.UpcomingTasksRepository.GetAllOrderedByLabel()
            );

            return Ok(tasks);
        }

        [HttpDelete("removeTasksFromProject/{projectId}")]
        public async Task<IActionResult> RemoveTasksFromProject(int projectId, int[] taskIds) 
        {
            if(taskIds.Count() < 1) return BadRequest("Nothing to remove");
            
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(projectId);

            if(project == null) return BadRequest("No project was found");

            var tasks = await _unitOfWork.TaskRepository.GetTaskByProjectIdAndPK(projectId, taskIds);

            _unitOfWork.TaskRepository.DeleteRange(tasks);

            if(await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Tasks failed to get deleted");
        }
    }
}