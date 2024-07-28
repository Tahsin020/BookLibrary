using BookLibrary.Web.Dtos;
using BookLibrary.Web.Models;
using BookLibrary.Web.Repositories;

namespace BookLibrary.Web.Services.BookLibrary;

public class BookLibraryService : IBookLibraryService
{
    private readonly IRepository<Book> _repository;

    public BookLibraryService(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public async Task CreateBookAsync(CreateBookDto model)
    {
        Book book = new Book
        {
            Author = model.Author,
            Name = model.Name,
            Status = model.Status
        };
        await _repository.CreateAsync(book);
    }


    public async Task DeleteBookAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(value);
    }

    public async Task<List<ResultBookDto>> GetAllBooksAsync()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new ResultBookDto
        {
            Author = x.Author,
            Id = x.Id,
            Name = x.Name,
            Status = x.Status
        }).ToList();
    }

    public async Task<GetByIdBookDto> GetByIdBookAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        if (value == null)
        {
            return new GetByIdBookDto();
        }
        return new GetByIdBookDto
        {
            Author = value.Author,
            Id = value.Id,
            Name = value.Name,
            Status = value.Status
        };
    }

    public async Task UpdateBookAsync(UpdateBookDto model)
    {
        var value = await _repository.GetByIdAsync(model.Id);
        value.Author = model.Author;
        value.Name = model.Name;
        value.Status = model.Status;
        await _repository.UpdateAsync(value);
    }

}

