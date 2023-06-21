namespace Services.Models
{

    public class SbdBidDocumentValueJsonModel
    {
        public string Name { get; set; } = string.Empty;

        public dynamic? Value { get; set; }

        public string ControlType { get; set; } = string.Empty ;
    }
}
