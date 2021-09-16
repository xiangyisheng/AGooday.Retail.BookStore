using AGooday.Retail.BookStore.Authors;
using AGooday.Retail.BookStore.Books;
using AutoMapper;

namespace AGooday.Retail.BookStore
{
    /// <summary>
    /// 继承：Profile
    /// https://docs.automapper.org/en/stable/Configuration.html
    /// </summary>
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            //让领域模型和视图模型产生关联
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();

            CreateMap<Author, AuthorDto>();

            CreateMap<Author, AuthorLookupDto>();
        }
    }
}
