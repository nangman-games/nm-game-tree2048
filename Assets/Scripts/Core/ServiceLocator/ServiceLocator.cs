using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NangMan.Core.ServiceLocator
{
    public class ServiceLocator
    {
        private static readonly Dictionary<Type, ServiceHandler> Services = new();

        public static bool Register<T>(IService service, int order = 0)
        {
            var key = typeof(T);
            if (Services.ContainsKey(key))
                return false;
            var handler = new ServiceHandler(service, order);
            Services.Add(key, handler);
            handler.Service.OnServiceRegistered();
            return true;
        }

        public static bool UnRegister<T>()
        {
            if (Services.TryGetValue(typeof(T), out var handler))
            {
                handler.Service.OnServiceUnRegistered();
                return true;
            }
            
            return false;
        }
        
        public static bool RegisterFromResources<T>(string loadPath, int order = 0) where T : ServiceMono
        {
            var res = Resources.Load<T>(loadPath);
            if (res == null)
            {
                Debug.LogError($"리소스 찾기 실패 : {loadPath}");
                return false;
            }
            var obj = Object.Instantiate(res, Vector3.zero, Quaternion.identity);
            if (obj == null)
            {
                Debug.LogError($"Instantiate 실패 : {loadPath}");
                return false;
            }
            
            return Register<T>(obj, order);
        }
    }
}