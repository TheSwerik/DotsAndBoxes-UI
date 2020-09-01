// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace UI.Services.Model
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public override string ToString() { return Message; }
    }
}