using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Articles
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
            List<string> bookInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Article article = new Article(bookInfo[0], bookInfo[1], bookInfo[2]);

            int n = int.Parse(Console.ReadLine());
            string[] data = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i <= n; i++)
            {
                // Edit: {new content}
                // ChangeAuthor: {new author}
                // Rename: {new title}

                string replacement = data[1];

                if (data[0] == "Edit")
                {
                    article.EditTheContent(replacement);
                }
                else if (data[0] == "ChangeAuthor")
                {
                    article.ChangeTheAuthor(replacement);
                }
                else if (data[0] == "Rename")
                {
                    article.RenameTheTitle(replacement);
                }

                if (i == n)
                {
                    break;
                }

                data = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }
            
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
