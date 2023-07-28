namespace coreEntityFrameworkCoreAdvancedConcepts.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
