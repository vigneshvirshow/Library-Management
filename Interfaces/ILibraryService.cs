using Library_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Interfaces
{
    public interface ILibraryService
    {
        public Task<List<BookDetails>> GetBookDetails();
        public Task InsertBook(InsertBookDetails bookDetails); 
        public Task UpdateBook(string bookName, int bookId); 
        public Task DeleteBook(int id); 
    }
}
