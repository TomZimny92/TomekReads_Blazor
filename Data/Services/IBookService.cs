﻿using TomekReads.Data.Models;

namespace TomekReads.Data.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllAsync();
        Task<Book?> GetBookAsync(int id);
        Task<Book?> AddBookAsync(Book book);
        Task<IEnumerable<Book>> AddBooksAsync(IEnumerable<Book> books);
        Task<bool> UpdateBookAsync(Book book);        
        Task<bool> DeleteBookAsync(int id);
        Task<bool> DeleteBooksAsync(IEnumerable<int> ids);
    }
}
