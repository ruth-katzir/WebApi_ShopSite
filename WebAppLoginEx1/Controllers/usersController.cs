using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Reflection.PortableExecutable;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        ILogger<usersController> logger;
        IUserService service;
        IPasswordsService servicePass;
        IMapper mapper;

        public usersController(IUserService service, IPasswordsService servicePass, IMapper mapper, ILogger<usersController> logger)
        {
            this.service = service;
            this.servicePass = servicePass;
            this.mapper = mapper;
            this.logger = logger;
        }


        // GET api/<usersController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            User user = await service.getbyIdAsync(id);
            UserDTO userDTO = mapper.Map<User, UserDTO>(user);
            return userDTO;
        }


        // POST api/<usersController>


        [HttpPost]
        public async Task<ActionResult<UserDTO>> LoginPost([FromBody] UserDTO loginUserDTO)
        {
            User loginUser = mapper.Map<UserDTO, User>(loginUserDTO);
            User found = await service.loginAsync(loginUser);
            if (found != null)
            {
                UserDTO foundDTO = mapper.Map<User, UserDTO>(found);
                logger.LogInformation($"Login - userName: {foundDTO.Email} at {DateTime.UtcNow.ToLongTimeString()}");
                return foundDTO;
            }
            return NoContent();
        }



        [HttpPost("regist")]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userRegistDTO)
        {
            Password pass = new Password(userRegistDTO.Password);
            if (servicePass.getPasswordRate(pass) > 2)
            {
                User userRegist = mapper.Map<UserDTO, User>(userRegistDTO);
                User userCreated = await service.registerAsync(userRegist);
                if (userCreated != null)
                {
                    UserDTO userDTOCreated = mapper.Map<User, UserDTO>(userCreated);
                    logger.LogInformation($"Regist - userName: {userDTOCreated.Email} at {DateTime.UtcNow.ToLongTimeString()}");
                    return CreatedAtAction(nameof(Get), new { id = userDTOCreated.Id }, userDTOCreated);
                }
                    
            }
            return BadRequest();
        }



        // PUT api/<usersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await service.updateAsync(userToUpdate, id);

        }

    }
}
