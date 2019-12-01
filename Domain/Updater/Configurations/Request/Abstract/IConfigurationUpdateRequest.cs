namespace Domain.Updater.Configurations.Request.Abstract
{
    public interface IConfigurationUpdateRequest
    {
        string Key { get; }
        string Value { get; }
        bool IsValid { get; }
    }
}
