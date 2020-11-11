using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UnitOfWorkInterceptor.Abstracts
{
    interface IOnBeforeCommit
    {
        Task OnBeforeCommit();
    }
}
