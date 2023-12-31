using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Utilities.Exceptions;

public class AlreadyFullException : Exception
{
    public AlreadyFullException(string message) : base(message) { }
}
