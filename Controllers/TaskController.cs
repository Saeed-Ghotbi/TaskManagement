using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Contracts.Repository;
using TaskManagement.DTOs.Task;
using TaskManagement.DTOs.Task.Validator;
using Task = TaskManagement.Model.Task;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> Get()
        {
            var tasks = await _taskRepository.GetAllTasks();

            return Ok(tasks);
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> Get(int id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTaskDto createTaskDto)
        {
            CreateTaskValidator validator = new CreateTaskValidator();
            var resultValidator = validator.Validate(createTaskDto);
            if (!resultValidator.IsValid)
            {
                return BadRequest(resultValidator.Errors);
            }

            var task = _mapper.Map<Task>(createTaskDto);

            await _taskRepository.Add(task);

            return NoContent();
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateTaskDto createTaskDto)
        {
            var userExist = await _taskRepository.Exist(id);
            if (userExist == false) { return NotFound(); }

            CreateTaskValidator validator = new CreateTaskValidator();
            var resultValidator = validator.Validate(createTaskDto);
            if (!resultValidator.IsValid)
            {
                return BadRequest(resultValidator.Errors);
            }

            var task = await _taskRepository.Get(id);

            _mapper.Map(createTaskDto, task);

            await _taskRepository.Update(task);

            return NoContent();
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var task = await _taskRepository.Get(id);

            if (task == null) { return NotFound(); }

            await _taskRepository.Delete(task);

            return NoContent();
        }
    }
}
