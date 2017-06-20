namespace ngVega.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Make Make { get; set; }
        public int MakeId { get; set; }
        // By convention, naming the property using the pattern parent_name + parent_property
        // it ensures it can be used as a foreign key. Ensure the types are the same (int).
    }
}