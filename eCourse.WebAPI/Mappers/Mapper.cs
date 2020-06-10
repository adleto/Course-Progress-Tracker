using AutoMapper;
using eCourse.Database.Entities;
using eCourse.Models.ApplicationUser;
using eCourse.Models.KursInstanca;
using eCourse.Models.Opcina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourse.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ApplicationUser, ApplicationUserModel>().ReverseMap();
            CreateMap<Role, RoleModel>();
            CreateMap<Opcina, OpcinaModel>();
            CreateMap<KursInstanca, KursInstancaModel>();
        }
    }
}
