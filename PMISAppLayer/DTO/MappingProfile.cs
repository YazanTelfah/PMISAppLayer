using AutoMapper;
using PMISAppLayer.DTO.ProjectDTO;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTO
{
    public class MappingProfile : Profile 
    {
        public MappingProfile ( )
        {
            CreateMap<InsertProjectDTO, Project>()
            .ForMember(des => des.ContractFile, opt => opt.Ignore());
            //CreateMap<UpdateProjectDTO, Project>()
            //.ForMember(des => des.ContractFile, opt => opt.Ignore());
        }
    }
}
