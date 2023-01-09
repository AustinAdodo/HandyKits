using HandyKits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class Ps5
    {
        private double epsilon = 1e-6;
    }

    public interface IAlertDAO
    {
        public Guid AddAlert(DateTime time);

        public DateTime GetAlert(Guid id);
    }

    public class AlertService
    {
        private readonly AlertDAO storage = new AlertDAO();
        private readonly IAlertDAO _IAlertDAO;

        public AlertService(IAlertDAO iAlertDAO)
        {
            _IAlertDAO = iAlertDAO;
        }
        public Guid RaiseAlert()
        {
            return _IAlertDAO.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return _IAlertDAO.GetAlert(id);
        }
    }

    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }

    public class Song
    {
        private string name { get; set; }
        public Song NextSong { get; set; }
        public List<Song> GetAllSongs { get; set; } = new List<Song>(); 
        public song(string name)
        {
            this.name = name;
        }
        public bool IsInRepeatingPlaylist()
        {
            if (this.GetAllSongs().Last() != null) return true;
            return false;
        }
    }
    //public static void Main(string[] args)
    //{
    //    List<Song> songs = new List<Song>();
    //    Song first = new Song("Hello");
    //    Song second = new Song("Eye of the tiger");
    //    songs.Add(first);
    //    songs.Add(second);

    //    first.NextSong = second;
    //    second.NextSong = first;

    //    Console.WriteLine(first.IsInRepeatingPlaylist());
    //}
}


