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
            CreateMap<Users, UsersDto>();
            CreateMap<List<Users>, List<UsersDto>>();
            CreateMap<Users, CreateUsersDto>();
        }
    }
}
