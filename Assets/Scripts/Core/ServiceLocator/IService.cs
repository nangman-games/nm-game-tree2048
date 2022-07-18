namespace NangMan.Core.ServiceLocator
{
    public interface IService
    {
        void OnServiceRegistered();
        void OnServiceUnRegistered();
        void OnServiceRestarted();
    }
}