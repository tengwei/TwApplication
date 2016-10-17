using System;
using System.Collections.Concurrent;
using Online.Common;
using Online.IServices;

namespace Online.Services {
    public static class CreateService {
        private static readonly ConcurrentDictionary<string, IService> dic = new ConcurrentDictionary<string, IService>();
        public static IService CreateIService(string typeName) {
            if (dic.ContainsKey(typeName)) {
                return dic[typeName];
            }
            else {
                //IService iService = typeof(IService).Assembly.CreateInstance(typeName) as IService;
                //Assembly assembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\Online.Services.dll"));
                //IService iService = assembly.CreateInstance(typeName) as IService;
                var typeFinder = new WebAppTypeFinder();
                var drTypes = typeFinder.FindClassesOfType<IService>();
                foreach (var drType in drTypes) {
                    dic.TryAdd(drType.FullName, (IService)Activator.CreateInstance(drType));
                }
                if (dic.ContainsKey(typeName)) {
                    return dic[typeName];
                }
                else {
                    throw new Exception("未实现" + typeName);
                }
            }
        }
    }
}
