namespace NangMan.Core.ServiceLocator
{
    internal class ServiceHandler
    {
        public ServiceHandler(IService service, int order)
        {
            Service = service;
            Order = order;
        }

        public IService Service { get; }
        public int Order { get; }
    }
}