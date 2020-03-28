using System.Web;

public class GetHandler : IHttpHandler
{
    public bool IsReusable
    {
        get => false; 
    }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = context.Request;
        HttpResponse response = context.Response;
        response.Write("Get handler");
    }
}