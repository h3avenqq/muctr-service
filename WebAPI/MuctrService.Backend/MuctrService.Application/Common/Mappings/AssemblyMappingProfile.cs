﻿using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace MuctrService.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var method = type.GetMethod("Mapping");
                method?.Invoke(instance, new object[] { this });
            }
        }
    }
}
