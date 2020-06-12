﻿using AutoMapper;
using eCourse.Database.Entities;
using eCourse.Models.ApplicationUser;
using eCourse.Models.Kurs;
using eCourse.Models.KursInstanca;
using eCourse.Models.Opcina;
using eCourse.Models.Tag;
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
            CreateMap<Tag, TagModel>();
            CreateMap<TagUpsertModel, Tag>();
            CreateMap<Kurs, KursModel>();
            CreateMap<Kurs, KursProsireniModel>().ReverseMap();
        }
    }
}
