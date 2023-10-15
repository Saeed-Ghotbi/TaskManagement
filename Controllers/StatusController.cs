using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Contracts.Repository;
using TaskManagement.DTOs.Status;
using TaskManagement.DTOs.Status.Validator;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStatusRepository _statusRepository;

        public StatusController(IMapper mapper, IStatusRepository statusRepository)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;
        }
        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<List<Status>>> Get()
        {
            var statuses = await _statusRepository.GetAll();

            return Ok(statuses);
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            var status = await _statusRepository.Get(id);
            if (status == null) { return NotFound(); }
            return Ok(status);
        }

        // POST api/<StatusController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StatusDto statusDto)
        {
            CreateStatusValidator validator = new CreateStatusValidator();
            var resultValidation = validator.Validate(statusDto);
            if (!resultValidation.IsValid)
            {
                return BadRequest(resultValidation.Errors);
            }

            var status = _mapper.Map<Status>(statusDto);
            var newUser = await _statusRepository.Add(status);
            return NoContent();
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StatusDto statusDto)
        {
            var userExist = await _statusRepository.Exist(id);
            if (userExist == false) { return NotFound(); }

            CreateStatusValidator validator = new CreateStatusValidator();
            var validationResult = validator.Validate(statusDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var status = await _statusRepository.Get(id);

            _mapper.Map(statusDto, status);

            await _statusRepository.Update(status);
            return NoContent();

        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _statusRepository.Get(id);

            if (status == null) { return NotFound(); }

            await _statusRepository.Delete(status);

            return NoContent();
        }
    }
}
