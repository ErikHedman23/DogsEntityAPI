namespace Dogs.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string Home { get; set; } = string.Empty;
        public int Age { get; set; }   
        public string Description { get; set; } = string.Empty;
    }
}
