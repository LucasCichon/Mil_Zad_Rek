
using Serilog;

namespace MilitarySuplierFilesConsoleApp.ErrorHandling
{
    public class ErrorHandler : IErrorHandler
    {
        public void Handle(Action request)
        {
            try
            {
                request.Invoke();
            }         
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, "Błąd IO podczas próby odczytania pliku");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Wystąpił nieoczekiwany błąd");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
