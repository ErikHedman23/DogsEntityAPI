namespace Dogs.Entities
{
    public class Dog
    {
        public int Id { get; set; } //autoincrementing id as the primary key
        public required string Name { get; set; } = string.Empty; //nvarchar(max) - not ideal, but just for test purposes
        public string Home { get; set; } = string.Empty; //nvarchar(max) - not ideal, but just for test purposes
        public int Age { get; set; } // int
        public string Description { get; set; } = string.Empty; //nvarchar(max) - not ideal, but just for test purposes
    }
}
