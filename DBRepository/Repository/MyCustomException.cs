using System;
using System.Collections.Generic;
using System.Text;

namespace DBRepository.Repository
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {
        }
    }

    public class NoDetailsFoundException : MyCustomException
    {
        public NoDetailsFoundException() : base("No details found with requested id")
        {

        }

        public NoDetailsFoundException(string message) : base(message)
        {
        }
    }


}
