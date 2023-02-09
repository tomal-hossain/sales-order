namespace API.Domain.Entity
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Window> Windows { get; set; }
    }
}
