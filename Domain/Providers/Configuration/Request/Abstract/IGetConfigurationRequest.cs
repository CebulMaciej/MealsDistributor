using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.Configuration.Request.Abstract
{
    public interface IGetConfigurationRequest
    {
        string Key { get; }
        bool IsValid { get; }
    }
}
