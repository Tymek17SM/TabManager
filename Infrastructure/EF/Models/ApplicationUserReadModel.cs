using Application.Mapping;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Models
{
    internal class ApplicationUserReadModel : IMap
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<DirectoryTabReadModel> DirectoryTabs { get; set; }
        public ICollection<TabReadModel> Tabs { get; set; } 

        void IMap.Mapping(Profile profile)
        {
            //throw new NotImplementedException();
        }
    }
}
