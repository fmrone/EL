using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EL.FredericoRibeiro.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("EL.FredericoRibeiro.Api"),
                Assembly.Load("EL.FredericoRibeiro.Application"),
                Assembly.Load("EL.FredericoRibeiro.Domain"),
                Assembly.Load("EL.FredericoRibeiro.Domain.Core"),
                Assembly.Load("EL.FredericoRibeiro.Infrastructure"),
                Assembly.Load("EL.FredericoRibeiro.CrossCutting")
            };
        }
    }
}
