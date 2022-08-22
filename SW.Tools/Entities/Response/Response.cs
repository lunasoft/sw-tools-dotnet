using System;

namespace SW.Tools.Entities.Response
{
    public class Response
    {
        public string status { get; set; } = "success";
        public string message { get; set; }
        public string messageDetail { get; set; }
    }
}
