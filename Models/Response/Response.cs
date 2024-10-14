namespace ShoppingList.WebApi.Models.Response
{
    public class Response
    {
        public Response()
        {
            Errors = new List<Error>();
        }
        public bool IsSuccess {
            get
            {
                return Errors == null || !Errors.Any();
            }    
        }
        public List<Error> Errors { get; set; }
    }
}
