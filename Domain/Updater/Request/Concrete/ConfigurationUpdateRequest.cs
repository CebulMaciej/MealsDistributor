using System;
using System.Collections.Generic;
using System.Text;
using Domain.Updater.Request.Abstract;

namespace Domain.Updater.Request.Concrete
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
