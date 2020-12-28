using System;
using System.Collections.Generic;
using System.Text;

namespace Yo.Api.Client.Models
{
    public static class HttpSettings
    {
        public static string BaseAddress { get; private set; } = @"http://localhost:56717/api/";

        public static void SetBaseAddress(string newAddress)
        {
            BaseAddress = newAddress;
        }
    }
}
