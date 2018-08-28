namespace ForumSystem.Web.Infrastructure.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public class AutoMapperConfig
    {
        public static IConfigurationProvider MapperConfiguration { get; private set; }

        private Assembly assembly;

        public AutoMapperConfig(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public void Execute()
        {
            var types = this.assembly.GetExportedTypes();

            MapperConfiguration = new MapperConfiguration(conf =>
            {
                //RegisterStandardFromMappings(configuration, types);

                //RegisterStandardToMappings(configuration, types);

                //RegisterCustomMaps(configuration, types);

                LoadStandardMappings(conf, types);

                LoadCustomMappings(conf, types);

            });

        }

        private static void LoadStandardMappings(IProfileExpression conf, IEnumerable<Type> types)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where
                           i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) && !t.IsAbstract
                           && !t.IsInterface
                       select new TypesMap
                       {
                           Source = i.GetGenericArguments()[0],
                           Destination = t
                       };

            foreach (var map in maps)
            {
                conf.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IMapperConfigurationExpression conf, IEnumerable<Type> types)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where typeof(IHaveCustomMappings).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface
                       select (IHaveCustomMappings)Activator.CreateInstance(t);

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }        
    }
}