using Core.Repository;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Service {
    public class ServiceLocator {

        private static Dictionary<Type, Type> Usuario = new Dictionary<Type, Type> {
            [typeof(IAmigo)] = typeof(AmigoRepository)
        };

        internal static T GetInstanceOf<T>() {
            return Activator.CreateInstance<T>();
        }
    }
}