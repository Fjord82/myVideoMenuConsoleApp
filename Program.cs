﻿using System;
using System.Collections.Generic;

namespace VideoMenuApp
{
    public class MainClass
    {
        static int id = 1;

        static List<Video> videoMenu = new List<Video>();

        public static void Main(string[] args)
        {
            InitWithMockData();

            Console.WriteLine("----------------------------------------------------------");
            string[] menuItems = {
                "List all videos",
                "Add a new video",
                "Remove a video",
                "Edit a video",
                "Close program"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListAllVideos();
                        break;
                    case 2:
                        AddNewVideo();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Program is shutting down....");
        }

        private static void InitWithMockData()
        {
            //Video example one
            videoMenu.Add(new Video()
            {
                VideoID = id++,
				Title = "Gremlings 3",
				Author = "Roald Dahl",
                Genre = "Horror/Comedy"
            });

			//Video example two
			videoMenu.Add(new Video()
            {
                VideoID = id++,
                Title = "Taxi",
                Author = "Steven King",
                Genre = "Action"
            });

			//Video example three
			videoMenu.Add(new Video()
			{
				VideoID = id++,
				Title = "Godfather chapter 2",
				Author = "Francis Ford Coppola",
				Genre = "Classic"
			});

			//Video example four
			videoMenu.Add(new Video()
			{
				VideoID = id++,
				Title = "The Departed",
				Author = "Martin Scorses",
				Genre = "Thriller"
			});

			//Video example five
			videoMenu.Add(new Video()
			{
				VideoID = id++,
				Title = "Rounders",
				Author = "Steven King",
				Genre = "Action"
			});

			//Video example six
			videoMenu.Add(new Video()
			{
				VideoID = id++,
				Title = "Shawshank Redemtion",
				Author = "Frank Darabont",
				Genre = "Drama"
			});
        }

        private static Video FindVideoById(out int videoId)
        {
            Console.WriteLine("Insert the video ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert an excisting Id: ");

            }
            videoId = id;
            foreach (var video in videoMenu)
            {
                if (video.VideoID == id)
                {
                    return video;
                }
                else
                {

                }
            }
            return null;
        }

        private static void ListAllVideos()
        {
            string cat1 = "ID:";
            string cat2 = "Title:";
            string cat3 = "Author:";
            string cat4 = "Genre:";
            Console.WriteLine("\nVideo menu list:\n");

            Console.WriteLine($"{cat1.PadRight(10, ' ')}" +
                              $"{cat2.PadRight(20, ' ')}" +
                              $"{cat3.PadRight(20, ' ')}" +
                              $"{cat4.PadRight(20, ' ')}\n" +
                                  $"______________________________________________________________");
            foreach (var video in videoMenu)
            {
                Console.WriteLine($"{Convert.ToString(video.VideoID.ToString("D4").PadRight(10, ' '))}" +
                                  $"{AddElipsisToString(video.Title).PadRight(20, ' ')}" +
                                  $"{AddElipsisToString(video.Author).PadRight(20, ' ')}" +
                                  $"{video.Genre.PadRight(20, ' ')}");
            }
            Console.WriteLine("\n");
        }

        private static void AddNewVideo()
        {
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Genre: ");
            string genre = Console.ReadLine();

            videoMenu.Add(new Video()
            {
                VideoID = id++,
                Title = title,
                Author = author,
                Genre = genre
            });
        }

        private static void DeleteVideo()
        {
            int videoIdFound;
            var videoExcist = FindVideoById(out videoIdFound);
            if (videoExcist != null)
            {
                videoMenu.Remove(videoExcist);
            }
            else
            {
                Console.WriteLine(videoIdFound + " did not exist inside the list, so nothing has been removed!");
            }
        }

        private static void EditVideo()
        {
            int videoIdFound;
            var videoExcist = FindVideoById(out videoIdFound);
            if (videoExcist != null)
            {
                //var video = FindVideoById();
                Console.WriteLine("Title: ");
                videoExcist.Title = Console.ReadLine();
                Console.WriteLine("Author: ");
                videoExcist.Author = Console.ReadLine();
                Console.WriteLine("Genre: ");
                videoExcist.Genre = Console.ReadLine();
                Console.WriteLine("Program is returning to main view.\n" +
                                  "____________________________________________");
            }
            else
            {
                Console.WriteLine("The ID entered does not excist!");
                EditVideo();
            }

        }

        private static int ShowMenu(string[] menuItems)
        {
            //Console.Clear();
            Console.WriteLine("Select a task\n" +
                              "________________");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                  || selection < 1
                  || selection > 5)
            {

                Console.WriteLine("Please select a number between 1-5");
            }
            return selection;
        }

        private static string AddElipsisToString(string stringValue)
        {
            string toView;
            const int maxView = 15;

            if (stringValue.Length > maxView)
            {
                toView = stringValue.Substring(0, maxView) + "..." + "  ";
            }
            else
            {
                toView = stringValue;
            }
            return toView;
        }

    }

}
