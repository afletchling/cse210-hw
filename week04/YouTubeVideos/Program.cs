using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = [
            new Video("How to make waffles", "MrBean", 346),
            new Video("Cute cat compilation", "Jeff Star", 823),
            new Video("New product review", "Marc Bezos", 655)
        ];

        videos.ForEach((Video video) =>
        {
            video.AddComment(new Comment("Mc Frenzy", "this was very insightful!"));
            video.AddComment(new Comment("Peter Dhar", "First"));
            video.AddComment(new Comment("Tater Roe", "Can I use this content in my video?"));
        });

        videos.ForEach((Video video) =>
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length}");
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}");
            Console.WriteLine("Comments: ");

            video._comments.ForEach((Comment comment) =>
            {
               Console.WriteLine($"- {comment._name}: {comment._text}");
            });

            Console.WriteLine("");
        });
    }
}