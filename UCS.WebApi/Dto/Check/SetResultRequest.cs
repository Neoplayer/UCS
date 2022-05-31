namespace UCS.WebApi.Dto.Check
{
    public class SetResultRequest
    {
        public int SessionId { get; set; }
        public int Result { get; set; }
        public string Comment { get; set; }
    }
}
