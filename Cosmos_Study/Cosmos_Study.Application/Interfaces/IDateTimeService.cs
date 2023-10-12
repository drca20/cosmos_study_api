using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos_Study.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
