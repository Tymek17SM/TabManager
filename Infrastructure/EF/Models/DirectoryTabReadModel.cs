using Application.Dto;
using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects.Directory;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Models
{
    internal class DirectoryTabReadModel : IMap
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool MainDirectory { get; set; }
        public DirectoryTabReadModel? SuperiorDirectory { get; set; }
        public DirectoryTabReadModel? SubordinateDirectory { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<TabReadModel> TabReadModels { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<DirectoryTabReadModel, DirectoryTabDto>()
                .ForMember(dirTabDto => dirTabDto.Tabs, opt => opt.MapFrom(t => t.TabReadModels));
        }
    }
}
