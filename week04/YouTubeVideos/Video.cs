using System;
using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments;

 
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

  
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        
       
        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine(new string('-', 50));
    }
}