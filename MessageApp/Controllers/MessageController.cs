using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitang.ONS.Treinamento.DTOEntities;
using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IService;

namespace MessageApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMapper mapperConstructor, IMessageService messageService)
        {
            _mapper = mapperConstructor;
            _messageService = messageService;
        }


        [HttpGet]
        [Route("{userId: long}/{contacId: long}")]
        public async Task<ActionResult<List<MessageDto>>> FetchConversation(long userId, long contactId)
        {
            var room = (await _messageService.CreateChatRoomAsync(userId, contactId)).ToList();
            if (room.Count() == 0 || room == null)
                room = null;

            var roomDto = _mapper.Map<List<Message>, List<MessageDto>>(room);
            return Ok(roomDto);
        }

        [HttpPost]
        [Route("{userId: long}/{contacId: long}/update")]
        public async Task<ActionResult<List<MessageDto>>> UpdateConversation(
            [FromBody]List<MessageDto> oldConversationDto, long userId, long contactId)
        {
            var oldConversation = _mapper.Map<List<MessageDto>, List<Message>>(oldConversationDto);
            var room = (await _messageService.UpdateChatRoomAsync(oldConversation, userId, contactId)).ToList();
            if (room.Count() == 0 || room == null)
                room = null;

            var roomDto = _mapper.Map<List<Message>, List<MessageDto>>(room);
            return Ok(roomDto);
        }

        [HttpPost]
        [Route("{userId: long}/{contacId: long}")]
        public async Task<ActionResult<MessageDto>> SendMessage(
            [FromBody] MessageDto messageDto)
        {
            var message = _mapper.Map<MessageDto, Message>(messageDto);
            message = await _messageService.SendMessageAsync(message);
            messageDto = _mapper.Map<Message, MessageDto>(message);
            
            return Ok(messageDto);
        }
    }
}