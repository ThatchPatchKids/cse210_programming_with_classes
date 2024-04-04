using System;
using System.ComponentModel;

public class Video 
{
    private string _title;

    private string _author;

    private int _length;

    List<Comment> _comments = new List<Comment>();


    public Video(string title, string author, int length)
    {
        this._title = title;
        this._author = author;
        this._length = length;
    }

    public int GetNumberComments()
    {
        return this._comments.Count;
    }

    public void DisplayComments()
    {
        foreach (Comment comment in this._comments)
        {
            comment.DisplayComment();
        }
    }

    public void DisplayVideo()
    {
        Console.WriteLine();
        Console.WriteLine($"The video: {this._title} by {this._author} is {this._length}s and has {this.GetNumberComments()} comments.");
    }

    public void AddComment(string name, string text)
    {
        this._comments.Add(new Comment(name, text));
    }

    public void AddComments()
    {
        bool adding = true;
        while (adding)
        {
            Console.Write("Would you like to add a comment (y/n)? ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Console.WriteLine("Please provide the following:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Comment: ");
                string text = Console.ReadLine();
                this.AddComment(name, text);
            }
            else
            {
                adding = false;
            }
        }
    }

    public List<Comment> GetComments()
    {
        return this._comments;
    }

    public override string ToString()
    {
        return $"{this._title}~{this._author}~{this._length}";
    }
}