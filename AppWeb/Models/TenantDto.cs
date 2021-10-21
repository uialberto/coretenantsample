namespace AppWeb.Models
{
    public class TenantDto
    {
        public TenantDto(int id, string identifier)
        {
            Id = id;
            Identifier = identifier;
            Items = new Dictionary<string, object>();
        }

        public int Id { get; }
        public string Identifier { get; }
        public Dictionary<string, object> Items { get; }
    }
}
