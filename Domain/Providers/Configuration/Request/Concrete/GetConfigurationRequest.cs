using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.Configuration.Request.Abstract;

namespace Domain.Providers.Configuration.Request.Concrete
{
    public class GetConfigurationRequest : IGetConfigurationRequest
    {
        public GetConfigurationRequest(string key)
        {
            Key = key;
        }

        public string Key { get; }
        public bool IsValid => !string.IsNullOrWhiteSpace(Key);
    }
}
