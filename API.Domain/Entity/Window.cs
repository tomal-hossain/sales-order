namespace API.Domain.Entity
{
    public class Window : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public virtual ICollection<SubElement> SubElements { get; set; }
    }
}
