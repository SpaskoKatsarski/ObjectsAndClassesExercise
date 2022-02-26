using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Articles_2._0
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void EditTheContent(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeTheAuthor(string newAuthorName)
        {
            this.Author = newAuthorName;
        }

        public void RenameTheTitle(string newTitle)
        {
            this.Title = newTitle;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            

            int n = int.Parse(Console.ReadLine());

            List<Article> allArticles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[]bookInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Article currArticle = new Article(bookInfo[0], bookInfo[1], bookInfo[2]);

                allArticles.Add(currArticle);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                foreach (var element in allArticles.OrderBy(e => e.Title))
                {
                    Console.WriteLine($"{element.Title} - {element.Content}: {element.Author}");
                }
            }
            else if (command == "content")
            {
                foreach (var element in allArticles.OrderBy(e => e.Content))
                {
                    Console.WriteLine($"{element.Title} - {element.Content}: {element.Author}");
                }
            }
            else if (command == "author")
            {
                foreach (var element in allArticles.OrderBy(e => e.Author))
                {
                    Console.WriteLine($"{element.Title} - {element.Content}: {element.Author}");
                }
            }
        }
    }
}
