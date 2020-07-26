using System;
using System.Collections.Generic;

namespace Code.Common.Experimental.SystemsOrderChecker
{
    public interface IRequireSystemsInvocationOrderChecker
    {
        List<Type> After();
    }
}