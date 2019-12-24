using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace Tests.Unit
{
    public class SolutionTests
    {
        readonly IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName!.ToLower().Contains("root") || 
                    s.FullName!.ToLower().Contains("tests"));

        [Fact]
        public void CheckAssembliesForAsyncVoid()
        {
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());

            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

            var methods = types.SelectMany(type => type.GetMethods(Flags));

            var asyncVoids = methods.Where(method =>
                method.GetCustomAttributes(typeof(AsyncStateMachineAttribute), false).Any() &&
                method.ReturnType == typeof(void));

            var messages = asyncVoids.Select(method =>
                $"'{method.DeclaringType?.Name}.{method.Name}' is an async void method.").ToArray();

            messages.Should().BeNullOrEmpty(
                $"Async void methods found!{Environment.NewLine}{string.Join(Environment.NewLine, messages)}");
        }

        [Fact]
        public void AssertConfigurationIsValid()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assemblies);
            });

            configuration.AssertConfigurationIsValid();
        }
    }
}