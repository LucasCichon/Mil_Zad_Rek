using MilitaryProductsFlaggingSystem.Common.Interfaces;

namespace MilitaryProductsFlaggingSystem.Application.Errors
{
    public class Error : IError
    {
        public Error(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
