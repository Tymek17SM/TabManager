using Application.Dto;
using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Models
{
    internal class TabReadModel : IMap
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DirectoryTabReadModel DirectoryTab { get; set; }
        public ApplicationUserReadModel Owner { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<TabReadModel, TabDto>()
                .ForMember(destinationMember => destinationMember.Id, options => options.MapFrom(source => source.Id))
                .ForMember(destinationMember => destinationMember.Name, options => options.MapFrom(source => source.Name))
                .ForMember(destinationMember => destinationMember.Link, options => options.MapFrom(source => source.Link))
                .ForMember(destinationMember => destinationMember.Description, options => options.MapFrom(source => source.Description))
                .ForMember(destinationMember => destinationMember.DdirectoryTabId, options => options.MapFrom(source => source.DirectoryTab.Id));
        }
    }
}
