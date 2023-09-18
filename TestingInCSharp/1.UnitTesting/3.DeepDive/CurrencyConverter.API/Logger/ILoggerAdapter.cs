namespace CurrencyConverter.API.Logger
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string messageTemplate, params object?[] args);
    }
}
