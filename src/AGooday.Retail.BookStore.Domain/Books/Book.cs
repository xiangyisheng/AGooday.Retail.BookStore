using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AGooday.Retail.BookStore.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public Guid AuthorId { get; set; }

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}
