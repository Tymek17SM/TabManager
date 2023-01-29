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
        public  ICollection<DirectoryTabReadModel> SubordinateDirectories { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public ApplicationUserReadModel Owner { get; set; }
        public ICollection<TabReadModel> Tabs { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<DirectoryTabReadModel, DirectoryTabDto>()
                .ForMember(destinationmember => destinationmember.Id, options => options.MapFrom(source => source.Id))
                .ForMember(destinationmember => destinationmember.Name, options => options.MapFrom(source => source.Name))
                .ForMember(destinationmember => destinationmember.MainDirectory, options => options.MapFrom(source => source.MainDirectory))
                .ForMember(destinationmember => destinationmember.SuperiorDirectoryId, options => options.MapFrom(source => source.SuperiorDirectory.Id))
                .ForMember(destinationmember => destinationmember.SubordinateDirectories, options => options.MapFrom(source => source.SubordinateDirectories))
                .ForMember(destinationmember => destinationmember.Tabs, options => options.MapFrom(source => source.Tabs));
        }
    }
}
