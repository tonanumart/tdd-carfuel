using System;

namespace CarFuel.Service.CustomException
{
    public class BussinessException : Exception
    {
        public Guid? UserId { get; set; }

        public BussinessException() : base("BussinessException")
        {

        }

        public BussinessException(string message)
        : base(message)
        {

        }

    }
}