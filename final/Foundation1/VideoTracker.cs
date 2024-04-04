using System;
using System.ComponentModel;

public class VideoTracker
{
    private List<Video> _videos = new List<Video>();

    public VideoTracker()
    {

    }

    public void DisplayVideos()
    {
        foreach (Video video in this._videos)
        {
            video.DisplayVideo();
            video.DisplayComments();
        }
    }

    public void AddVideo(string title, string author, int length)
    {
        this._videos.Add(new Video(title, author, length));
        this._videos[this._videos.Count-1].AddComments();
    }

    public void AddVideos()
    {
        bool adding = true;
        while (adding)
        {
            Console.WriteLine("Would you like to add a video (y/n)? ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Console.WriteLine("Please provide the following information:");
                Console.Write("Video Title: ");
                string title = Console.ReadLine();
                Console.Write("Video Author: ");
                string author = Console.ReadLine();
                Console.Write("Video Length in Seconds: ");
                int length = int.Parse(Console.ReadLine());
                this.AddVideo(title, author, length);
            }
            else
            {
                adding = false;
            }
        }
    }

    public void SaveVideos()
    {
        Console.Write("What is the filename for the videos file? ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Video video in this._videos)
            {
                outputFile.WriteLine(video.ToString());
                foreach (Comment comment in video.GetComments())
                {
                    outputFile.WriteLine(comment.GetComment());
                }
            }
        }
    }

    public void LoadVideos()
    {
        Console.Write("What is the filename for the videos file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~");
            if (line.StartsWith(":"))
            {
                this._videos[this._videos.Count-1].AddComment(parts[0].TrimStart(':'), parts[1]);
            }
            else
            {
                this._videos.Add(new Video(parts[0], parts[1], int.Parse(parts[2])));
            }
        }
    }
}