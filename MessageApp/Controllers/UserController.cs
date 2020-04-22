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
        public IUserService userService;
        private readonly IMapper mapper;

        public UserController(IMapper mapperConstructor)
        {
            this.mapper = mapperConstructor;
        }


        [HttpGet]
        [Route ("")]
        public ActionResult<List<UserDto>> ListUsers() //usar 'async Task<>' / 'await'
        {
            List<UserModel> usersModel = userService.listUsers();
            if(usersModel.Count == 0)
                return NotFound(null);

            List<UserDto> usersDto = mapper.Map<List<UserModel>, List<UserDto>>(usersModel);

            return Ok(usersDto);
        }

        [HttpPost]
        [Route ("")]
        public ActionResult<UserDto> AddUser(UserDto userDto)
        {
            if(userDto == null)
            {
                return NotFound("No user to add");
            }
            UserModel user = mapper.Map<UserDto, UserModel>(userDto);
            userService.addUser(user);
            userDto = mapper.Map<UserModel, UserDto>(user);

            return Ok(userDto);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<UserDto> UpdateUser(long id, [FromBody] UserDto userDto)
        {
            if(userDto == null) { return NotFound("Nothing to update"); }
            userDto.Id = id;
            UserModel user = mapper.Map<UserDto, UserModel>(userDto);
            userService.updateUser(user);
            userDto = mapper.Map<UserModel, UserDto>(user);

            return Ok(userDto);
        }

        [HttpGet]
        [Route ("FindUserName/{UserName}")]
        public ActionResult<UserDto> FindByUserName(string UserName)
        {
            UserModel user = userService.findUserByUsername(UserName);
            UserDto userDto = mapper.Map<UserModel, UserDto>(user);

            return Ok(userDto);
        }

    }
}