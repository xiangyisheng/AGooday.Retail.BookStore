using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AGooday.Retail.BookStore.Authors
{
    public class AuthorPageListInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
