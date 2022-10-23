using System;
using System.Collections.Generic;
using System.Text;

namespace programmingObjectOrientedExcercise
{
    class HandleErrorException
        : Exception
    {
        public HandleErrorException(string message)
            : base(message)
        {
        }

    }
}
