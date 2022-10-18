using BookStore.Books;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                for (int i = 0; i < 1000; i++)
                {
                    await _bookRepository.InsertAsync(
                        new Book
                        {
                            Name = $"Book {i}",
                            Type = (BookType)new Random().Next(8),
                            PublishDate = DateTime.Now,
                            Price = (float)(new Random().NextDouble() * 100) + 10,
                        },
                        autoSave: true
                    );
                }
            }
        }
    }
}
