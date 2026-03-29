using System;

public class Comment
{
    public string _commenterName;
    public string _text;

    // Constructor para inicializar el comentario
    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    // Método para mostrar el comentario
    public void DisplayComment()
    {
        Console.WriteLine($"    - {_commenterName}: \"{_text}\"");
    }
}