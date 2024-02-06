using System;
using System.ComponentModel.DataAnnotations;

public class PromptGenerator 
{
    int _promptCount = 0;
    HashSet<int> _indexSet = new HashSet<int>();

    public List<string> _prompts = new List<string>() 
                {
                    "Who was the most interesting person I interacted with today?",
                    "What was the best part of my day?",
                    "How did I see the hand of the Lord in my life today?",
                    "What was the strongest emotion I felt today?",
                    "If I had one thing I could do over today, what would it be?"
                };
    public PromptGenerator()
    {
    }

    public string GetRandomPrompt()
        {
            Random random = new Random();
            int randIndex = -1;
            bool valid = false;
            while (!valid)
            {
                randIndex = random.Next(_prompts.Count);
                bool containsNumber = _indexSet.Contains(randIndex);

                if (!containsNumber)
                {
                    _indexSet.Add(randIndex);
                    _promptCount += 1;
                    valid = true;  
                } 
                else if (_promptCount == _prompts.Count)
                {
                    return "Thats all the prompts for today!";
                }
            }

            string prompt = _prompts[randIndex];

            return prompt;
        }
}