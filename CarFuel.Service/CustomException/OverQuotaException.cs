using System;

namespace CarFuel.Service.CustomException
{
    public class OverQuotaException : BussinessException
    {
        public OverQuotaException(string message) :
            base(message)
        {

        }
    }
}