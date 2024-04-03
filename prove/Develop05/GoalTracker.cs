
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;

public class GoalTracker
{
    private List<string> _menuOptions =  new List<string>()
    {
        "   1. Create New Goal",
        "   2. List Goals",
        "   3. Save Goals",
        "   4. Load Goals",
        "   5. Record Event",
        "   6. Quit"
    };

    private List<string> _goalTypes = new List<string>()
    {
        "   1. Simple Goal",
        "   2. Eternal Goal",
        "   3. Checklist Goal",
        "   4. Negative Goal"
    };

    private int _menuChoice;

    private int _typeChoice;
    private int _totalPoints;

    private List<Goal> _goals = new List<Goal>();

    public GoalTracker()
    {
        this._totalPoints = 0;
    }

    public void CalculatePoints(int points)
    {
        this._totalPoints += points;
    }

    public void DisplayPoints()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {this._totalPoints} points.");
        Console.WriteLine();
    }

    public void DisplayOptions()
    {
        Console.WriteLine("Menu Options:");

        foreach(string option in this._menuOptions)
        {
            Console.WriteLine(option);
        }
    }

    public void SetMenuChoice()
    {
        bool valid = false;
        while (!valid)
        {
            try
            {
                Console.Write("Select a choice from the menu: ");
                this._menuChoice = int.Parse(Console.ReadLine());
                valid = true;
            }
            catch
            {
                Console.WriteLine("Sorry, invalid input.");
            }
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i_goal = 0; i_goal < this._goals.Count; i_goal++)
        {
            Console.Write($"{i_goal+1}. ");
            this._goals[i_goal].DisplayGoal();
        }
    }

    public void DisplayGoalTypes()
    {
        Console.WriteLine("The types of Goals are: ");
        foreach (string type in this._goalTypes)
        {
            Console.WriteLine(type);
        }
    }

    public void SetTypeChoice()
    {
        bool valid = false;
        while (!valid)
        {
            try
            {
                Console.Write("Which type of goal would you like to create? ");
                this._typeChoice = int.Parse(Console.ReadLine());
                valid = true;
            }
            catch
            {
                Console.WriteLine("Sorry, invalid input.");
            }
        }
    }

    public void CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());

        switch (this._typeChoice)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
                this._goals.Add(simpleGoal);
                break;
            case 2:
                EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                this._goals.Add(eternalGoal);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int numTimes = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, numTimes, bonus);
                this._goals.Add(checklistGoal);
                break;
            case 4:
                NegativeGoal negativeGoal = new NegativeGoal(goalName, goalDescription, goalPoints);
                this._goals.Add(negativeGoal);
                break;
            default:
                Console.WriteLine("Sorry, that is not a choice.");
                break;
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(this._totalPoints);

            foreach (Goal goal in this._goals)
            {
                outputFile.WriteLine(goal.ToString());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~");
            string goalName = parts[0];

            if (int.TryParse(line, out int totalPoints))
            {
                this._totalPoints = totalPoints;
            }

            switch (goalName)
            {
                case "SimpleGoal":
                    this._goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                    if (bool.Parse(parts[4]))
                    {
                        this._goals[this._goals.Count-1].SetCompleted();
                    }
                    break;
                case "EternalGoal":
                    this._goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    this._goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4])));
                    for (int i=0; i < int.Parse(parts[6]); i++)
                    {
                        this._goals[this._goals.Count - 1].SetCompleted();
                    }
                    break;
                case "NegativeGoal":
                    this._goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                    for (int i=0; i < int.Parse(parts[4]); i++)
                    {
                        this._goals[this._goals.Count - 1].SetCompleted();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        
        for (int i = 0; i < this._goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {this._goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int i_goal = int.Parse(Console.ReadLine());
        this._goals[i_goal-1].SetCompleted();
        Console.WriteLine($"Congratulations! You have earned {this._goals[i_goal-1].GetPoints()} points!");
        CalculatePoints(this._goals[i_goal-1].GetPoints());
    }

    public void RunGoalMenu()
    {
        bool running = true;
        while (running)
        {
            DisplayPoints();
            DisplayOptions();
            SetMenuChoice();

            switch(this._menuChoice)
            {
                case 1:
                    DisplayGoalTypes();
                    SetTypeChoice();
                    CreateGoal();
                    break;
                case 2:
                    DisplayGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                RecordEvent();
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Sorry, that is not an option.");
                    break;
            }
        }
    }
}