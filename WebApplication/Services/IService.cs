namespace DemoEF.Services
{
    public interface IService
    {
        void GetNumber();
        Guid GetGuidTransiant();
        Guid GetGuidScoped();
        Guid GetGuidSingleton();
    }
}
