using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.Config.Objects
{
    public class ConfigurationObject
    {
        public ConfigurationObject(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }
    }
}
