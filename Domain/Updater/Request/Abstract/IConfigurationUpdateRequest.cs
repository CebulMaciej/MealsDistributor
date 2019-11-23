using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Updater.Request.Abstract
{
    public interface IConfigurationUpdateRequest
    {
        string Key { get; }
        string Value { get; }
        bool IsValid { get; }
    }
}
