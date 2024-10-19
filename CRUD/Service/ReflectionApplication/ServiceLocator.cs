using System.Reflection;
using System.Linq;
using CRUD.DAL.Entities;
using CRUD.DAL.Repository;

namespace CRUD.Service.ReflectionApplication;

public static class ServiceLocator
{
    public static Dictionary<Type, List<Type>> FindAllRepositories<T>()
    {
        Dictionary<Type, List<Type>> resultDictionary = new();

        var targetType = typeof(T);
        
        var assembly = Assembly.GetExecutingAssembly();

        var targetClasses = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && targetType.IsAssignableFrom
            (t)).ToList();

        foreach (var cl in targetClasses)
        {
            var interFaceType = typeof(IRepository<>).MakeGenericType(cl);
            var classList = assembly.GetTypes().Where(t => interFaceType.IsAssignableFrom(t) && !t.IsAbstract).ToList();
            resultDictionary.TryAdd(interFaceType, classList);
        }

        return resultDictionary;
    }
}
