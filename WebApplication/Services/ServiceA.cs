namespace DemoEF.Services
{
    public class ServiceA : IService
    {
        public ServiceTransient _serviceTransient;
        public ServiceScoped _serviceScoped;
        public ServiceSingleton _serviceSingleton;
        public ServiceA(ServiceTransient serviceTransient, ServiceScoped serviceScoped,
                ServiceSingleton serviceSingleton)
        {
            _serviceSingleton = serviceSingleton;
            _serviceScoped = serviceScoped;
            _serviceTransient = serviceTransient;
        }
        public Guid GetGuidScoped()
        {
            return _serviceScoped.Guid;
        }

        public Guid GetGuidSingleton()
        {
            return _serviceSingleton.Guid;
        }

        public Guid GetGuidTransiant()
        {
            return _serviceTransient.Guid;
        }

        public void GetNumber()
        {
            throw new NotImplementedException();
        }
    }
}
