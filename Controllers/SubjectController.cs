using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Contracts.Repository;
using TaskManagement.DTOs.Subject;
using TaskManagement.DTOs.Subject.Validator;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(IMapper mapper, ISubjectRepository subjectRepository)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }
        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            var subjects = await _subjectRepository.GetAll();
            return Ok(subjects);
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> Get(int id)
        {
            var subject = await _subjectRepository.Get(id);
            if (subject == null) { return NotFound(); }
            return Ok(subject);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubjectDto subjectDto)
        {
            CreateSubjectValidator validator = new CreateSubjectValidator();
            var resultValidation = validator.Validate(subjectDto);
            if (!resultValidation.IsValid)
            {
                return BadRequest(resultValidation.Errors);
            }

            var subject = _mapper.Map<Subject>(subjectDto);
            var newUser = await _subjectRepository.Add(subject);
            return NoContent();
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SubjectDto subjectDto)
        {
            var userExist = await _subjectRepository.Exist(id);
            if (userExist == false) { return NotFound(); }

            CreateSubjectValidator validator = new CreateSubjectValidator();
            var validationResult = validator.Validate(subjectDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var subject = await _subjectRepository.Get(id);

            _mapper.Map(subjectDto, subject);

            await _subjectRepository.Update(subject);
            return NoContent();
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var subject = await _subjectRepository.Get(id);

            if (subject == null) { return NotFound(); }

            await _subjectRepository.Delete(subject);

            return NoContent();
        }
    }
}
