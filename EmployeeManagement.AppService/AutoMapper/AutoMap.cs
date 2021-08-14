using AutoMapper;
using EmployeeManagement.AppService.Dtos;
using EmployeeManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService.AutoMapper
{
    public class AutoMap: Profile
    {
        public AutoMap()
        {
            CreateMap<CreateRolesDto, Roles>();
            CreateMap<RegistrationDto, Registration>();
            CreateMap<Users, Members>();
            CreateMap<List<Users>, List<Members>>();
            CreateMap<Users, CreateUsersDto>();
            CreateMap<UpdateMembersDto, Users>();
        }
    }
}
