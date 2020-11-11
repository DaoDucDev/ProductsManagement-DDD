using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.SeedWork
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
