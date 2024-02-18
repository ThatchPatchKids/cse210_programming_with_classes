/*
 * Copyright (c) 2024 Brother Keers, Brigham Young University Idaho
 */

// Static class to generate prompts for journal entries
public static class PromptGenerator
{
    // Array of predefined prompts
    private static readonly string[] prompts =
    {
        "Write about your childhood home and how it made you feel.",
        "Describe a stranger you saw today in vivid detail.",
        "What do you want to achieve in the next 5 years?",
        "Pick a historical event and describe how it would be different if one key detail was changed.",
        "Imagine you woke up with a superpower. What would it be, and how would you use it?",
        "Write a story about a time you faced a difficult decision.",
        "Create a character and describe their most defining traits, both positive and negative.",
        "Describe a place that holds special meaning to you, using all five senses.",
        "Write a fictional news article about a groundbreaking discovery or event.",
        "If you could travel back in time to any period, where would you go and why?",
        "Write about a time you learned something important about yourself or someone else.",
        "Imagine you could have any animal as a pet. What would you choose, and why?",
        "Describe your dream home in detail."
    };

    // Method to get a random prompt from the array
    public static string GetPrompt()
    {
        // Create a random number generator
        Random rnd = new Random();

        // Generate a random index to select a prompt
        int index = rnd.Next(prompts.Length);

        // Return the randomly selected prompt
        return prompts[index];
    }
}
