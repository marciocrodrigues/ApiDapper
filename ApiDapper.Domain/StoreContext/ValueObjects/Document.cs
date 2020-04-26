namespace ApiDapper.Domain.StoreContext.ValueObjects
{
    public class Document
    {
        public Document(string number)
        {
            Numbem = number;
        }
        public string Numbem { get; set; }

        public override string ToString()
        {
            return Numbem;
        }
    }
}