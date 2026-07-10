namespace librosApi.Domain
{
    public class Book
    {
        public int Id { get; set; }
        required public string Title { get; set; }

        public int AuthorId { get; set;}
        required public Author Author { get; set; }

        required public string Genre { get; set; }
    }
}
