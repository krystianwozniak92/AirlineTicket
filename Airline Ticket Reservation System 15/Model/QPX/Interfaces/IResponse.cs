using Model.QPX.Response;

namespace Model.QPX.Interfaces
{
    public interface IResponse
    {
        string Kind { get; set; }

        Trips Trips { get; set; }
    }
}
