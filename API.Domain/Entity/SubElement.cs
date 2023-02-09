namespace API.Domain.Entity
{
    public class SubElement : BaseEntity
    {
        public int Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Window Window { get; set; }
        public int WindowId { get; set; }
    }
}
