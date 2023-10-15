using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Contracts.Repository;
using TaskManagement.DTOs.User;
using TaskManagement.DTOs.User.Validator;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IProfileUserRepository _profileRepository;

        public UserController(IMapper mapper, IUserRepository userRepository, IProfileUserRepository profileRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _userRepository.GetAll();
            if (users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null) { return NotFound(); }
            return Ok(user);

        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDto userDto)
        {
            CreateUserValidator validator = new CreateUserValidator();
            var validationResult = validator.Validate(userDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = _mapper.Map<User>(userDto);
            var newUser = await _userRepository.Add(user);

            var profile = _mapper.Map<ProfileUser>(userDto);
            profile.UserId = newUser.Id;
            await _profileRepository.Add(profile);

            return NoContent();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDto userDto)
        {
            var userExist = await _userRepository.Exist(id);
            if (userExist == false) { return NotFound(); }

            UpdateUserValidator validator = new UpdateUserValidator();
            var validationResult = validator.Validate(userDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _userRepository.Get(id);
            var profile = await _profileRepository.GetByUserId(id);

            _mapper.Map(userDto, user);

            await _userRepository.Update(user);

            _mapper.Map(userDto, profile);

            await _profileRepository.Update(profile);

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userRepository.Get(id);

            if (user == null) { return NotFound(); }

            await _userRepository.Delete(user);

            return NoContent();
        }
    }
}
