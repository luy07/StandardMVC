using AutoMapper;
using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dto.Profiles
{
    public class CustomerProfile : Profile
    {

        protected override void Configure()
        {
            var map = Mapper.CreateMap<Customer, CustomerDto>();
            map.ForMember(dto => dto.FullName, mc => mc.MapFrom(e => e.FirstName + " " + e.LastName));
            map.ForMember(dto => dto.Birthday, mc => mc.MapFrom(e => e.Birthday.ToString("yyyy.MM.dd")));
        }
    }
}
