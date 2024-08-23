namespace BankPortal.API.Models
{
    using System.Text.Json;

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        // Convert the object to a JSON string using System.Text.Json
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
