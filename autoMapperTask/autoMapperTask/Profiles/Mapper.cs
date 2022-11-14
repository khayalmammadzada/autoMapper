using System;
using AutoMapper;
using autoMapperTask.DTOs.DepartmentDtos;
using autoMapperTask.Entities;

namespace autoMapperTask.Profiles;

public class Mapper:Profile
{
    public Mapper()
    {
        CreateMap<Department, DepartmentGetDto>();
    }
}

