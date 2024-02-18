using System;

public class Scripture
{
    private List<Word> _words;

    public Scripture(string text)
    {
        this._words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayWords()
    {
        foreach (Word word in this._words)
        {
            word.DisplayWord();
        }
    }

    public void HideWords(int numToHide)
    {
        Random random = new Random();

        var wordsToHide = this._words.Where(word => !word.IsHidden()).OrderBy(_ => random.Next()).Take(numToHide);

        foreach (Word word in wordsToHide)
        {
            word.HideWord();
        }
    }

    public bool AreHidden()
    {
        foreach (Word word in this._words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}