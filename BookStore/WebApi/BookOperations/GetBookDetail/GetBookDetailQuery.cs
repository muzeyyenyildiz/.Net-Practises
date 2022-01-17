using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery 
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if(book is null){
                throw new InvalidOperationException("Book couldn't found");
            }
            BookDetailViewModel wm = new BookDetailViewModel();
           
            wm.Title = book.Title;
            wm.PageCount = book.PageCount;
            wm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            wm.Genre = ((GenreEnum)book.GenreId).ToString();
            return wm;
        }

    }

    public class BookDetailViewModel
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int PageCount { get; set; }
        public string? PublishDate { get; set; }

    }
}