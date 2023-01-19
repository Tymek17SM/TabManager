using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class DirectoryTabDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool MainDirectory { get; set; }
        public Guid? SuperiorDirectoryId { get; set; }
        public ICollection<DirectoryTabDto> SubordinateDirectories { get; set; }
        public ICollection<TabDto>? Tabs { get; set; }
    }
}
