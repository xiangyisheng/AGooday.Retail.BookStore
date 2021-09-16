using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AGooday.Retail.BookStore.Books
{
    public class CreateUpdateBookDto : IValidatableObject
    {
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(BookConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(0, 999.99)]
        public float Price { get; set; }

        //IValidatableObject自定义验证逻辑
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == Description)
            {
                yield return new ValidationResult(
                    "Name and Description can not be the same!",
                    new[] { "Name", "Description" }
                );
            }
        }
    }
}
