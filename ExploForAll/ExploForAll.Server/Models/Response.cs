namespace ExploForAll.Server.Models
{
    public class Response
    {
        public ResponseTypes Status { get; set; }
        public string Message { get; set; }

        public Response()
        {

        }

        public Response(ResponseTypes type, string message)
        {
            Status = type;
            Message = message;
        }
    }
}
