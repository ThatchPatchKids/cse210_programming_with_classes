using System;

public class Comment 
{
    private string _name;

    private string _text;

    public Comment(string name, string text)
    {
        this._name = name;
        this._text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine(this._name);
        Console.WriteLine(this._text);
        Console.WriteLine();
    }

    public string GetComment()
    {
        return $":{this._name}~{this._text}";
    }
}