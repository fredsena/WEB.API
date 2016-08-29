namespace Sms.Data.Interfaces
{
    public interface IServiceLocator
    {
        T Resolve<T>();
    }
}
