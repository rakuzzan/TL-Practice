using Core.Models;
using DatabaseProvider;
using DatabaseProvider.Repositories.Abstractions;
using DatabaseProvider.Repositories.Implementations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace CoachDB
{
    public class Program
    {
        private const string ConnectionString =
           "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CoachDBEF;Pooling=true;Integrated Security=SSPI";

        private static ApplicationContext _applicationContext;

        private static ICoach _coach;
        private static ICompetition _competition;
        private static IStudio _studio;
        private static IViewer _viewer;
        private static IWatched _watched;

        public static void Main()
        {
            _applicationContext = new ApplicationContext(ConnectionString);

            _coach = new CoachRepository(_applicationContext);
            _competition = new CompetitionRepository(_applicationContext);
            _studio = new StudioRepository(_applicationContext);
            _viewer = new ViewerRepository(_applicationContext);
            _watched = new WatchedRepository(_applicationContext);


        }

        public static void ProccessCommands()
        {
            while (true)
            {
                Console.Write("Enter command: ");
                string[] commandLine = Console.ReadLine().Split(' ');
                string command = commandLine[0];
                List<string> parameters = commandLine.Skip(1).ToList();

                switch (command)
                {
                    // Service
                    case "exit":
                        return;
                    case "help":
                        Console.WriteLine($"Usage: XXX-YYY-ZZ parameter parameter parameter ...");
                        break;

                        
                    // Competition

                    case "get-all-countries":
                        GetAllCountries();
                        break;
                    case "get-competition-by-id":
                        GetCompetitionById(parameters);
                        break;
                    case "add-competition":
                        AddCompetition(parameters);
                        break;
                    case "delete-competition":
                        DeleteCompetition(parameters);
                        break;

                    // Studio

                    case "get-all-studios":
                        GetAllStudios();
                        break;
                    case "get-studio-by-id":
                        GetStudioById(parameters);
                        break;
                    case "add-studio":
                        AddStudio(parameters);
                        break;
                    case "delete-studio":
                        DeleteStudio(parameters);
                        break;

                    // Coach

                    case "get-all-coachs":
                        GetAllCoachs();
                        break;
                    case "get-coach-by-id":
                        GetCoachById(parameters);
                        break;
                    case "add-coach":
                        AddCoach(parameters);
                        break;
                    case "delete-coach":
                        DeleteCoach(parameters);
                        break;

                    // Viewer
                    case "get-all-viewers":
                        GetAllViewers();
                        break;
                    case "get-viewer-by-id":
                        GetViewerById(parameters);
                        break;
                    case "add-viewer":
                        AddViewer(parameters);
                        break;
                    case "delete-viewer":
                        DeleteViewer(parameters);
                        break;


                    // Watched

                    case "get-all-watched":
                        GetAllWatched();
                        break;
                    case "get-watched-by-viewer-id":
                        GetWatchedByViewerId(parameters);
                        break;
                    case "get-watched-by-coach-id":
                        GetWatchedByCoachId(parameters);
                        break;
                    case "get-watched-by-id":
                        GetWatchedById(parameters);
                        break;
                    case "add-watched":
                        AddWatched(parameters);
                        break;
                    case "delete-watched":
                        DeleteWatched(parameters);
                        break;

                    default:
                        Console.WriteLine("Unknow command");
                        break;
                }


            }
        }
        public static void GetAllCountries()
        {
            List<Competition> countries = _competition.GetAll();

            if (countries.Count == 0)
            {
                Console.WriteLine("The count of countries are zero.");
            }

            foreach (Competition Competition in countries)
            {
                Console.WriteLine(Competition);
            }
        }

        public static void GetCompetitionById(List<string> parameters)
        {
            int CompetitionId = int.Parse(parameters[1]);

            Competition Competition = _competition.GetById(CompetitionId);
            if (Competition == null)
            {
                Console.WriteLine($"Competition with id {CompetitionId} does not exist.");
                return;
            }
        }

        public static void AddCompetition(List<string> parameters)
        {
            Competition Competition = new()
            {
                NameOfCompetition = parameters[1]
            };

            _competition.Add(Competition);
            _competition.SaveChanges();
        }

        public static void DeleteCompetition(List<string> parameters)
        {
            int CompetitionId = int.Parse(parameters[1]);
            Competition Competition = _competition.GetById(CompetitionId);

            _competition.Remove(Competition);
            _competition.SaveChanges();
        }

        // Studio

        public static void GetAllStudios()
        {
            List<Studio> studios = _studio.GetAll();

            if (studios.Count == 0)
            {
                Console.WriteLine("The count of studios are zero.");
                return;
            }

            foreach (Studio studio in studios)
            {
                Console.WriteLine(studio);
            }
        }

        public static void GetStudioById(List<string> parameters)
        {
            int studioId = int.Parse(parameters[1]);

            Studio studio = _studio.GetById(studioId);

            if (studio == null)
            {
                Console.WriteLine($"Competition with id {studioId} does not exist.");
                return;
            }
        }

        public static void AddStudio(List<string> parameters)
        {

            Studio studio = new()
            {
                Name = parameters[1],
                FoundationYear = DateTime.Parse(parameters[2]),
                CompetitionId = int.Parse(parameters[3]),
                Competition = _competition.GetById(int.Parse(parameters[4])),
                CEO = parameters[5]
            };

            _studio.Add(studio);
            _studio.SaveChanges();
        }

        public static void DeleteStudio(List<string> parameters)
        {
            int studioId = int.Parse(parameters[1]);

            Studio studio = _studio.GetById(studioId);

            _studio.Remove(studio);
            _studio.SaveChanges();
        }

        // Coach 

        public static void GetAllCoachs()
        {
            List<Coach> Coachs = _coach.GetAll();

            if (Coachs.Count == 0)
            {
                Console.WriteLine("The count of Coach are zero.");
            }

            foreach (Coach Coach in Coachs)
            {
                Console.WriteLine(Coach);
            }
        }

        public static void GetCoachById(List<string> parameters)
        {
            int CoachId = int.Parse(parameters[1]);

            Coach Coach = _coach.GetById(CoachId);

            if (Coach == null)
            {
                Console.WriteLine($"Coach with id {CoachId} does not exist");
                return;
            }

            Console.WriteLine(Coach);
        }

        public static void AddCoach(List<string> parameters)
        {
            Coach Coach = new()
            {
                Title = parameters[1],
                ReleaseDate = DateTime.Parse(parameters[2]),
                Genre = parameters[3],
                StudioId = int.Parse(parameters[4]),
                Studio = _studio.GetById(int.Parse(parameters[5])),
                AgeRatings = (byte)int.Parse(parameters[6])
            };

            _coach.Add(Coach);
            _coach.SaveChanges();
        }

        public static void DeleteCoach(List<string> parameters)
        {
            int CoachId = int.Parse(parameters[1]);

            Coach Coach = _coach.GetById(CoachId);

            _coach.Remove(Coach);
            _coach.SaveChanges();
        }

        // Viewer

        public static void GetAllViewers()
        {
            List<Viewer> viewers = _viewer.GetAll();

            if (viewers.Count == 0)
            {
                Console.WriteLine("The count of viewers are zero");
            }

            foreach (Viewer viewer in viewers)
            {
                Console.WriteLine(viewer);
            }
        }

        public static void GetViewerById(List<string> parameters)
        {
            int viewerId = int.Parse(parameters[1]);

            Viewer viewer = _viewer.GetById(viewerId);

            if (viewer == null)
            {
                Console.WriteLine($"Viewer with id {viewerId} does not exist");
                return;
            }
            Console.WriteLine(viewer);
        }

        public static void AddViewer(List<string> parameters)
        {
            Viewer viewer = new()
            {
                Nickname = parameters[1],
                Age = (byte)int.Parse(parameters[2]),
                Gender = (byte)int.Parse(parameters[3])
            };

            _viewer.Add(viewer);
            _viewer.SaveChanges();
        }

        public static void DeleteViewer(List<string> parameters)
        {
            int viewerId = int.Parse(parameters[1]);

            Viewer viewer = _viewer.GetById(viewerId);

            _viewer.Remove(viewer);
            _viewer.SaveChanges();
        }

        // Watched

        public static void GetAllWatched()
        {
            List<Watched> watcheds = _watched.GetAll();

            if (watcheds.Count == 0)
            {
                Console.WriteLine("The count of watcheds are zero.");
            }

            foreach (Watched watched in watcheds)
            {
                Console.WriteLine(watched);
            }
        }

        public static void GetWatchedById(List<string> parameters)
        {
            int watchedId = int.Parse(parameters[1]);

            Watched watched = _watched.GetWatchedById(watchedId);

            if (watched == null)
            {
                Console.WriteLine($"The watch with id {watchedId} does not exist");
                return;
            }

            Console.WriteLine(watched);
        }

        public static void GetWatchedByCoachId(List<string> parameters)
        {
            int CoachId = int.Parse(parameters[1]);

            List<Watched> watched = _watched.GetByCoachId(CoachId);

            if (watched.Count == 0)
            {
                Console.WriteLine($"Coach with id {CoachId} does not exist or nobody don't watch it");
                return;
            }

            foreach (Watched w in watched)
            {
                Console.WriteLine(w);
            }
        }

        public static void GetWatchedByViewerId(List<string> parameters)
        {
            int viewerId = int.Parse(parameters[0]);

            List<Watched> watcheds = _watched.GetByViewerId(viewerId);

            if (watcheds.Count == 0)
            {
                Console.WriteLine($"The viewer with id {viewerId} does not exist or doesn't watch any Coach.");
            }

            foreach (Watched watched in watcheds)
            {
                Console.WriteLine(watched);
            }
        }

        public static void AddWatched(List<string> parameters)
        {
            int CoachId = int.Parse(parameters[0]);
            int viewerId = int.Parse(parameters[1]);

            Coach Coach = _coach.GetById(CoachId);

            if (Coach == null)
            {
                Console.WriteLine($"The Coach with id {CoachId} does not exist");
                return;
            }

            Viewer viewer = _viewer.GetById(viewerId);

            if (viewer == null)
            {

                Console.WriteLine($"The viewer with id {viewerId} does not exist");
                return;
            }

            Watched watched = new()
            {
                CoachId = CoachId,
                Coach = _coach.GetById(CoachId),

                ViewerId = viewerId,
                Viewer = _viewer.GetById(viewerId)
            };

            _watched.Add(watched);
            _watched.SaveChanges();
        }

        public static void DeleteWatched(List<string> parameters)
        {
            int watchedId = int.Parse(parameters[1]);

            Watched watched = _watched.GetWatchedById(watchedId);

            _watched.Remove(watched);
            _watched.SaveChanges();
        }

    }
}