using System;

public class Reference
{
    private bool hasRead;
    private string _book;
    private string _chapter;
    private string _verse;
    private Scripture _scripture;

    public Reference(string book, string chapter, string verse, string scripture)
    {
        this._book = book;
        this._chapter = chapter;
        this._verse = verse;
        this._scripture = new Scripture(scripture);
    }

    public void DisplayScripture()
    {
        Console.Write($"{_book} {_chapter}:{_verse} ");
        if (!hasRead)
        {
            _scripture.DisplayWords();
            hasRead = true;
        }
        else
        {
            _scripture.HideWords(3);
            _scripture.DisplayWords();
        }
    }

    public bool IsHidden()
    {
        return _scripture.AreHidden();
    }
}