namespace NangMan.Core.ServiceLocator
{
    internal abstract class Service : IService
    {
        public abstract void OnServiceRegistered();
        public abstract void OnServiceUnRegistered();
        public abstract void OnServiceRestarted();
    }
}