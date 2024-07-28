using BookLibrary.Web.Dtos;

namespace BookLibrary.Web.Services.BookLibrary;

public interface IBookLibraryService
{
    Task<List<ResultBookDto>> GetAllBooksAsync();
    Task<GetByIdBookDto> GetByIdBookAsync(int id);
    Task CreateBookAsync(CreateBookDto model);
    Task UpdateBookAsync(UpdateBookDto model);
    Task DeleteBookAsync(int id);
}
