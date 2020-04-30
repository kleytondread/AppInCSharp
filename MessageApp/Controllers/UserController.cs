using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pitang.ONS.Treinamento.DTOEntities;
using Pitang.ONS.Treinamento.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitang.ONS.Treinamento.IService;
using AutoMapper;

namespace Pitang.ONS.Treinamento.MessageApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapperConstructor, IUserService userService)
        {
            _mapper = mapperConstructor;
            _userService = userService;
        }


        [HttpGet]
        [Route ("")]
        public async Task<ActionResult<List<UserDtoOutput>>> ListUsers()
        {
            var users = (await _userService.ListUsersAsync()).ToList();

            if(users.Count() == 0 || users == null)
                return NotFound("No user available");

            List<UserDtoOutput> usersDto = _mapper.Map<List<UserModel>, List<UserDtoOutput>>(users.ToList());

            return Ok(usersDto);
        }

        [HttpPost]
        [Route ("")]
        public async Task<ActionResult<UserDtoOutput>> AddUser([FromBody] UserDtoInput userDtoInput)
        {
            if(userDtoInput == null)
            {
                return NotFound("No user to add");
            }
            UserModel user = _mapper.Map<UserDtoInput, UserModel>(userDtoInput);
            await _userService.AddUserAsync(user);
            var userDto = _mapper.Map<UserModel, UserDtoOutput>(user);

            return Ok(userDto);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<UserDtoOutput> UpdateUser(long id, [FromBody] UserDtoInput userDto)
        {
            if(userDto == null) { return NotFound("Nothing to update"); }
            userDto.Id = id;
            UserModel user = _mapper.Map<UserDtoInput, UserModel>(userDto);
            _userService.UpdateUser(user);
            var userDtoOutput = _mapper.Map<UserModel, UserDtoOutput>(user);

            return Ok(userDtoOutput);
        }

        [HttpGet]
        [Route ("FindUserName/{UserName}")]
        public ActionResult<UserDtoOutput> FindByUserName(string UserName)
        {
            UserModel user = _userService.FindUserByUsername(UserName);
            UserDtoOutput userDto = _mapper.Map<UserModel, UserDtoOutput>(user);

            return Ok(userDto);
        }

    }
}