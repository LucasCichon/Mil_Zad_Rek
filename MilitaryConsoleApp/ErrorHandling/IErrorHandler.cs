
namespace MilitaryConsoleApp.ErrorHandling
{
    public interface IErrorHandler
    {
        T Handle<T>(Func<T> request);
        Task HandleAsync(Func<Task> request);
    }
}
