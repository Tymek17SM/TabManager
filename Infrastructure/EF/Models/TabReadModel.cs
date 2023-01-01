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
        public DirectoryTabReadModel DirectoryTabReadModel { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<TabReadModel, TabDto>();
        }
    }
}
