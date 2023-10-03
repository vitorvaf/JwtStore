using Flunt.Notifications;

namespace JwtStore.Core.Context.AccountContext.UseCases
{
    public class Response : SharedCotext.UseCases.Response
    {
        private Response() 
        {

        }

        public Response(            
            string message,
            int status,
            IEnumerable<Notification>? notifications = null) 
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public Response(string message, ResponseData response )
        {
            Message = message;
            Status = 201;
            ResponseData = response;
            Notifications = null;

        }

        public ResponseData? ResponseData { get; set; }
        
    }

    public record ResponseData(Guid Id, string Name, string Email);
}