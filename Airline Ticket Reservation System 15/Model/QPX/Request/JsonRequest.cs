namespace Model.QPX.Request
{
    public class JsonRequest
    {
        public Request Request { get; set; }

        public JsonRequest()
        {
            Request = new Request();
        }

        public JsonRequest(string json) : this()
        {
            Request = new Request(json);
        }
    }
}
