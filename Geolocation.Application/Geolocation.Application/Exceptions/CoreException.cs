using System;

namespace Geolocation.Application.Exceptions
{
    public class CoreException : Exception
    {
        public virtual string Code { get; }

        protected CoreException(string message) : base(message)
        {
        }
    }
}
