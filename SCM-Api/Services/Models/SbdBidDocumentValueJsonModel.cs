namespace Services.Models
{

    public class SbdBidDocumentValueJsonModel
    {
        public string Name { get; set; } = null!;

        public dynamic? Value { get; set; }

        public string ControlType { get; set; } = null!;
    }
}
