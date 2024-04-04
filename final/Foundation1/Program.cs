using System;

class Program
{
    static void Main(string[] args)
    {
        VideoTracker videos = new VideoTracker();
        // videos.AddVideos();
        // videos.SaveVideos();
        
        videos.LoadVideos();
        videos.DisplayVideos();
    }
}