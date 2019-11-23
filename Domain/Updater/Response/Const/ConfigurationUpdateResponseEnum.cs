using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Updater.Response.Const
{
    public enum ConfigurationUpdateResponseEnum
    {
        Exception = 0,
        Success=1,
        NotFound = 2,
        BadRequest = 3
    }
}
