using UnityEngine;

namespace NangMan.Core.ServiceLocator
{
    public abstract class ServiceMono : MonoBehaviour, IService
    {
        public void OnServiceRegistered()
        {
            DontDestroyOnLoad(gameObject);
        }

        public abstract void OnServiceRegisteredImpl();
        public abstract void OnServiceUnRegistered();
        public abstract void OnServiceRestarted();
    }
}