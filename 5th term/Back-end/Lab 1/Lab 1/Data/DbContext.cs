using Lab_1.Models;
using System.Collections.Generic;
using System;

namespace Lab_1.Data
{
    public class DbContext
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User(){Id = 1, Name = "Ira"},
            new User(){Id = 2, Name = "Dima"},
            new User(){Id = 3, Name = "Jim"},
        };

        public static List<Category> Categories { get; set; } = new List<Category>()
        {
            new Category(){Id = 1, Name = "Food"},
            new Category(){Id = 2, Name = "Courses"},
            new Category(){Id = 3, Name = "Books"},
            new Category(){Id = 4, Name = "Toys"},
            new Category(){Id = 5, Name = "Subscriptions"},
        };

        public static List<Record> Records { get; set; } = new List<Record>()
        {
            new Record(){Id = 1, UserId = 1, CategoryId = 1, CreatedOnUtc = GetRandomDate(), Sum = 250},
            new Record(){Id = 2, UserId = 1, CategoryId = 2, CreatedOnUtc = GetRandomDate(), Sum = 100},
            new Record(){Id = 3, UserId = 2, CategoryId = 3, CreatedOnUtc = GetRandomDate(), Sum = 400},
            new Record(){Id = 4, UserId = 2, CategoryId = 4, CreatedOnUtc = GetRandomDate(), Sum = 175},
            new Record(){Id = 5, UserId = 2, CategoryId = 5, CreatedOnUtc = GetRandomDate(), Sum = 25},
            new Record(){Id = 6, UserId = 3, CategoryId = 1, CreatedOnUtc = GetRandomDate(), Sum = 125}
        };

        private static DateTime GetRandomDate()
        {
            Random random = new Random();
            var currentTime = DateTime.UtcNow;

            return new DateTime(
                currentTime.Year,
                currentTime.Month - random.Next(1, 4),
                currentTime.Day - random.Next(1, 10)
            );
        }
    }
}
