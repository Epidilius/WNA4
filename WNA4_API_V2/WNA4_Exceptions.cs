using System;

namespace WNA4_API_V2
{
    public class WNA4_Exceptions
    {
        public class InvalidTokenException : WNA4_Exception
        {
            public InvalidTokenException() : base()
            {

            }

            public InvalidTokenException(string message) : base(message)
            {

            }
        }

        public class InvalidPassWordException : WNA4_Exception
        {
            public InvalidPassWordException() : base()
            {

            }
        }

        public class ContactDoesNotExistException : WNA4_Exception
        {
            public ContactDoesNotExistException() : base()
            {

            }
        }

        public class WNA4_Exception : Exception
        {
            public WNA4_Exception() : base() { }
            public WNA4_Exception(string message) : base(message) { }
            public WNA4_Exception(string format, params object[] args) : base(string.Format(format, args)) { }
            public WNA4_Exception(string message, Exception innerException) : base(message, innerException) { }
            public WNA4_Exception(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
        }
    }
}
