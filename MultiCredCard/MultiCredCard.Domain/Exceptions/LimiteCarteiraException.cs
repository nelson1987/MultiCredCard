using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCredCard.Domain.Exceptions
{
    [Serializable]
    public class LimiteCarteiraException : Exception
    {
        public LimiteCarteiraException(string message) : base(message)
        {
        }
    }
}
