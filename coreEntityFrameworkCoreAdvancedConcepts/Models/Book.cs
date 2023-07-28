namespace coreEntityFrameworkCoreAdvancedConcepts.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
