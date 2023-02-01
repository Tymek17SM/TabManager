namespace WebAPI.Wrappers
{
    public class Response 
    {
        public Response()
        {

        }

        public Response(string message, bool succeeded)
        {
            Message = message;
            Succeeded = succeeded;
        }

        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }

    public class Response<T> : Response
    {
        public Response()
        {

        }

        public Response(T data)
        {
            Data = data;
            Succeeded = true;
        }

        public T Data { get; set; }
    }
}
