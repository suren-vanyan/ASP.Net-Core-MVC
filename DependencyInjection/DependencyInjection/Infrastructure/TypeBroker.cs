using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Infrastructure
{
    public static class TypeBroker
    {
        private static Type repoType = typeof(MemoryRepositroy);
        private static IRepository testRepo;

        public static IRepository Repository =>
            testRepo ?? Activator.CreateInstance(repoType) as IRepository;

        public static void SetRepositoryType<T>() where T : IRepository =>
            repoType = typeof(T);

        public static void SetTestObject(IRepository repo)
        {
            testRepo = repo;
        }
    }
}
