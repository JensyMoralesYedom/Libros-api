namespace librosApi.Domain
{
    public class Author
    {
        public int Id { get; set; }
        required public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
