using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pitang.ONS.Treinamento.DTOEntities;
using Pitang.ONS.Treinamento.Entities;

namespace Pitang.ONS.Treinamento.MessageApp.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDtoInput>();
            CreateMap<UserDtoInput, UserModel>();

            CreateMap<UserModel, UserDtoOutput>();
            CreateMap<UserDtoOutput, UserModel>();

            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();

            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}
