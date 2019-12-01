using Domain.Updater.Configurations.Request.Abstract;

namespace Domain.Updater.Configurations.Request.Concrete
{
    public class ConfigurationUpdateRequest : IConfigurationUpdateRequest
    {
        public ConfigurationUpdateRequest(string key,string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }
        public bool IsValid => !string.IsNullOrWhiteSpace(Key)&& !string.IsNullOrWhiteSpace(Value);
    }
}
