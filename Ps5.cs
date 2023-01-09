using HandyKits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private static Song instance = null;
        public Song(string name)
        {
            this.name = name;
        }

        public bool IsInRepeatingPlaylist()
        {
            //if (this.NextSong != null && this. ) return true;
            return false;
        }
    }
    public static class solution
    {
        public static void x()
        {
            List<Song> songs = new List<Song>();
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");
            first.NextSong = second;
            second.NextSong = first;
            Console.WriteLine(first.IsInRepeatingPlaylist());
        }
    }

    public class TextInput
    {
        public string val { get; set; }
        public virtual void Add(char value) { this.val += value.ToString(); }
        public string GetValue() { return this.val.ToString(); }
    }

    public class NumericInput : TextInput
    {
        int a = 0;
        public string tin { get; set; }
        public override void Add(char value)
        {
            if (int.TryParse(value.ToString(), out a))
            {
                this.tin += a;
            }
            this.val = this.tin;
        }
    }
}


