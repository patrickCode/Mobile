namespace Chronos.Core.Model
{
    public class LaborCategory
    {
        public LaborCategory() { }
        public LaborCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}