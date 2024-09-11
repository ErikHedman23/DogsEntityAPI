namespace Dogs.Entities
{
    public class Dog
    {
        public int Id { get; set; } //autoincrementing id as the primary key
        public required string Name { get; set; } = string.Empty; //nvarchar(50)
        public string Home { get; set; } = string.Empty; //nvarchar(50)
        public int Age { get; set; } // int
        public string Description { get; set; } = string.Empty; //nvarchar(100)
    }
}
