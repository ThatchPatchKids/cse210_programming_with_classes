using System;

public class Word
{
    private string _word;
    private string _hiddenWord;
    private bool _hidden;

    public Word(string word)
    {
        this._word = word;

        foreach (char letter in _word)
        {
            _hiddenWord += "_";
        }
    }

    public void HideWord()
    {
        this._hidden = true;
    }

    public bool IsHidden()
    {
        return this._hidden;
    }

    public void DisplayWord()
    {
        if (!_hidden)
        {
            Console.Write(_word + " ");
        }
        else
        {
            Console.Write(_hiddenWord + " ");
        }
    }
}