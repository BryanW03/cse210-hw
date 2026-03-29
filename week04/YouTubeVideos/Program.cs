using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
     
        List<Video> videos = new List<Video>();

   
        Video video1 = new Video("Advanced Power BI Dashboards with Deneb", "DataVizMaster", 1250);
        video1._comments.Add(new Comment("BI_Guy", "This custom visual configuration is exactly what I needed."));
        video1._comments.Add(new Comment("DataNerd99", "Great explanation of UI/UX styling."));
        video1._comments.Add(new Comment("ReportBuilder", "Can you share the JSON config?"));
        videos.Add(video1);

    
        Video video2 = new Video("MLB The Show: Gameplay & Franchise Mode", "SportsGamerX", 840);
        video2._comments.Add(new Comment("BaseballFan", "The new hitting mechanics look incredible."));
        video2._comments.Add(new Comment("Pitcher23", "Awesome gameplay footage."));
        video2._comments.Add(new Comment("GamerPro", "When is the next tournament?"));
        videos.Add(video2);

     
        Video video3 = new Video("Resolving C# MSB1003 Errors in .NET", "CodeFixer", 420);
        video3._comments.Add(new Comment("DevStudent", "Thank you! This saved my environment setup."));
        video3._comments.Add(new Comment("CSharpCoder", "Clear and concise debugging steps."));
        video3._comments.Add(new Comment("TechLead", "Good breakdown of the SDK configuration."));
        video3._comments.Add(new Comment("NewbieIT", "Very helpful for my first project."));
        videos.Add(video3);

      
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}