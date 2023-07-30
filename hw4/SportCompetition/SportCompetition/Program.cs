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
           "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportCompetitionEF;Pooling=true;Integrated Security=SSPI";

        private static ApplicationContext _applicationContext;

        private static ICoach _coach;
        private static ICompetition _competition;
        private static ISportsman _sportsman;
        private static IPerformance _performance;
        private static ISportType _sportType;

        public static void Main()
        {
            _applicationContext = new ApplicationContext(ConnectionString);

            _coach = new CoachRepository(_applicationContext);
            _competition = new CompetitionRepository(_applicationContext);
            _sportsman = new SportsmanRepository(_applicationContext);
            _performance = new PerformanceRepository(_applicationContext);
            _sportType = new SportTypeRepository(_applicationContext);


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

                    case "get-all-competitions":
                        GetAllCompetitions();
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

                    // Sportsman

                    case "get-all-Sportsmans":
                        GetAllSportsmans();
                        break;
                    case "get-Sportsman-by-id":
                        GetSportsmanById(parameters);
                        break;
                    case "add-Sportsman":
                        AddSportsman(parameters);
                        break;
                    case "delete-Sportsman":
                        DeleteSportsman(parameters);
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

                    // Performance
                    case "get-all-performances":
                        GetAllPerformances();
                        break;
                    case "get-performance-by-id":
                        GetPerformanceById(parameters);
                        break;
                    case "add-performance":
                        AddPerformance(parameters);
                        break;
                    case "delete-performance":
                        DeletePerformance(parameters);
                        break;


                    // SportType

                    case "get-all-sport-type":
                        GetAllSportType();
                        break;
                    case "get-sport-type-by-id":
                        GetSportTypeById(parameters);
                        break;
                    case "add-sport-type":
                        AddSportType(parameters);
                        break;
                    case "delete-sport-type":
                        DeleteSportType(parameters);
                        break;

                    default:
                        Console.WriteLine("Unknow command");
                        break;
                }


            }
        }
        public static void GetAllCompetitions()
        {
            List<Competition> competitions = _competition.GetAll();

            if (competitions.Count == 0)
            {
                Console.WriteLine("The count of competitions are zero.");
            }

            foreach (Competition competition in competitions)
            {
                Console.WriteLine(competition);
            }
        }

        public static void GetCompetitionById(List<string> parameters)
        {
            int competitionId = int.Parse(parameters[1]);

            Competition competition = _competition.GetById(competitionId);
            if (competition == null)
            {
                Console.WriteLine($"Competition with id {competitionId} does not exist.");
                return;
            }
        }

        public static void AddCompetition(List<string> parameters)
        {
            Competition competition = new()
            {
                Title = parameters[1],
                Date = DateTime.Parse(parameters[2]),
                Venue = parameters[3]
            };

            _competition.Add(competition);
            _competition.SaveChanges();
        }

        public static void DeleteCompetition(List<string> parameters)
        {
            int competitionId = int.Parse(parameters[1]);
            Competition competition = _competition.GetById(competitionId);

            _competition.Remove(competition);
            _competition.SaveChanges();
        }

        // Sportsman

        public static void GetAllSportsmans()
        {
            List<Sportsman> sportsmans = _sportsman.GetAll();

            if (sportsmans.Count == 0)
            {
                Console.WriteLine("The count of sportsmans are zero.");
                return;
            }

            foreach (Sportsman sportsman in sportsmans)
            {
                Console.WriteLine(sportsman);
            }
        }

        public static void GetSportsmanById(List<string> parameters)
        {
            int sportsmanId = int.Parse(parameters[1]);

            Sportsman sportsman = _sportsman.GetById(sportsmanId);

            if (sportsman == null)
            {
                Console.WriteLine($"Competition with id {sportsmanId} does not exist.");
                return;
            }
        }

        public static void AddSportsman(List<string> parameters)
        {

            Sportsman sportsman = new()
            {
                FirstName = parameters[1],
                LastName = parameters[2],
                CoachId = int.Parse(parameters[3]),
                Coach = _coach.GetById(int.Parse(parameters[4]))
            };

            _sportsman.Add(sportsman);
            _sportsman.SaveChanges();
        }

        public static void DeleteSportsman(List<string> parameters)
        {
            int sportsmanId = int.Parse(parameters[1]);

            Sportsman sportsman = _sportsman.GetById(sportsmanId);

            _sportsman.Remove(sportsman);
            _sportsman.SaveChanges();
        }

        // Coach 

        public static void GetAllCoachs()
        {
            List<Coach> coachs = _coach.GetAll();

            if (coachs.Count == 0)
            {
                Console.WriteLine("The count of Coach are zero.");
            }

            foreach (Coach coach in coachs)
            {
                Console.WriteLine(coach);
            }
        }

        public static void GetCoachById(List<string> parameters)
        {
            int coachId = int.Parse(parameters[1]);

            Coach coach = _coach.GetById(coachId);

            if (coach == null)
            {
                Console.WriteLine($"Coach with id {coachId} does not exist");
                return;
            }

            Console.WriteLine(coach);
        }

        public static void AddCoach(List<string> parameters)
        {
            Coach coach = new()
            {
                FirstName = parameters[1],
                LastName = parameters[2],
                BirthDate = DateTime.Parse(parameters[3])
            };

            _coach.Add(coach);
            _coach.SaveChanges();
        }

        public static void DeleteCoach(List<string> parameters)
        {
            int coachId = int.Parse(parameters[1]);

            Coach coach = _coach.GetById(coachId);

            _coach.Remove(coach);
            _coach.SaveChanges();
        }

        // Performance

        public static void GetAllPerformances()
        {
            List<Performance> performances = _performance.GetAll();

            if (performances.Count == 0)
            {
                Console.WriteLine("The count of performances are zero");
            }

            foreach (Performance performance in performances)
            {
                Console.WriteLine(performance);
            }
        }

        public static void GetPerformanceById(List<string> parameters)
        {
            int performanceId = int.Parse(parameters[1]);

            Performance performance = _performance.GetById(performanceId);

            if (performance == null)
            {
                Console.WriteLine($"Performance with id {performanceId} does not exist");
                return;
            }
            Console.WriteLine(performance);
        }

        public static void AddPerformance(List<string> parameters)
        {
            Performance performance = new()
            {
                Value = double.Parse(parameters[1]),
                SportsmanId = int.Parse(parameters[2]),
                Sportsman = _sportsman.GetById(int.Parse(parameters[4])),
                CompetitionId = int.Parse(parameters[5]),
                Competition = _competition.GetById(int.Parse(parameters[6])),
                SportTypeId = int.Parse(parameters[7]),
                SportType = _sportType.GetById(int.Parse(parameters[8])),

            };

            _performance.Add(performance);
            _performance.SaveChanges();
        }

        public static void DeletePerformance(List<string> parameters)
        {
            int performanceId = int.Parse(parameters[1]);

            Performance performance = _performance.GetById(performanceId);

            _performance.Remove(performance);
            _performance.SaveChanges();
        }

        // SportType

        public static void GetAllSportType()
        {
            List<SportType> sportTypes = _sportType.GetAll();

            if (sportTypes.Count == 0)
            {
                Console.WriteLine("The count of SportTypes are zero.");
            }

            foreach (SportType sportType in sportTypes)
            {
                Console.WriteLine(sportType);
            }
        }

        public static void GetSportTypeById(List<string> parameters)
        {
            int sportTypeId = int.Parse(parameters[1]);

            SportType sportType = _sportType.GetById(sportTypeId);

            if (sportType == null)
            {
                Console.WriteLine($"The sport type with id {sportTypeId} does not exist");
                return;
            }

            Console.WriteLine(sportType);
        }

        public static void AddSportType(List<string> parameters)
        {
            SportType sportType = new()
            {
                Title = parameters[1],
                UnitOfMeasurment = parameters[2],
            };

            _sportType.Add(sportType);
            _sportType.SaveChanges();
        }

        public static void DeleteSportType(List<string> parameters)
        {
            int sportTypeId = int.Parse(parameters[1]);

            SportType sportType = _sportType.GetById(sportTypeId);

            _sportType.Remove(sportType);
            _sportType.SaveChanges();
        }

    }
}