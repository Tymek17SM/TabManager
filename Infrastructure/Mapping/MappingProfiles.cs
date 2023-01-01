using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    internal sealed class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            ApplyMappingsFromExecutingAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromExecutingAssembly(Assembly assembly)
        {
            var types = assembly
                .DefinedTypes
                .Where(t => t.IsAssignableTo(typeof(IMap)) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IMap>()
                .ToList();

            types.ForEach(t => t.Mapping(this));



                
        }

    }
}
