using System;

namespace ConsoleApp1
{
    internal class Response
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ResponsePhrase { get; set; }
        public string ErrorMessage { get; set; }
        public String Data { get; set; }
    }
}
