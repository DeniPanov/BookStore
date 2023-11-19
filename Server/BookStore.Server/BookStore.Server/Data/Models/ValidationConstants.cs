namespace BookStore.Server.Data.Models
{
    public class ValidationConstants
    {
        public class Book
        {
            public const int TitleMaxLength = 150;
            public const int DescriptionMaxLength = 2000    ;
            public const int SummaryMaxLength = 1000;
            public const int ISBNMaxLength = 13;
            public const int AuthorMaxLength = 100;
            public const int MinYear = 0;
            public const int MaxYear = 2023;
        }
    }
}
