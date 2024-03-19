using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment2.Components.Pages.Data
{
    internal class Flight
    {
        public const int RecordSize = 72;

        private string _code;
        private string _airline;
        private string _from;
        private string _to;
        private string _weekday;
        private string _time;
        private int _seats;
        private double _costPerSeat;

        public Flight(string code)
        {
            ParseCode(code);
        }

        public Flight(string code, string airline, string from, string to, string weekday, string time, int seats, double costPerSeat)
        {
            _code = code;
            _airline = airline;
            _from = from;
            _to = to;
            _weekday = weekday;
            _time = time;
            _seats = seats;
            _costPerSeat = costPerSeat;
        }

        public string Code { get => _code; set => _code = value; }
        public string Airline { get => _airline; set => _airline = value; }
        public string From { get => _from; set => _from = value; }
        public string To { get => _to; set => _to = value; }
        public string Weekday { get => _weekday; set => _weekday = value; }
        public string Time { get => _time; set => _time = value; }
        public int Seats { get => _seats; set => _seats = value; }
        public double CostPerSeat { get => _costPerSeat; set => _costPerSeat = value; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Flight flight = (Flight)obj;

            return _code == flight._code &&
                   _airline == flight._airline &&
                   _from == flight._from &&
                   _to == flight._to &&
                   _weekday == flight._weekday &&
                   _time == flight._time &&
                   _seats == flight._seats &&
                   _costPerSeat == flight._costPerSeat;
        }

        public bool IsDomestic()
        {
            return _from[0] == 'Y' && _to[0] == 'Y';
        }

        public override string ToString()
        {
            return _code;
        }

        private void ParseCode(string code)
        {
            if (!Regex.Match(code, "^[A-Z]{2}-\\d{4}$").Success)
            {
                throw new ArgumentException("Invalid flight code format.");
            }

            string abbreviation = code.Substring(0, 2);

            _airline = abbreviation switch
            {
                "OA" => "Otto Airlines",
                "CA" => "Conned Air",
                "TB" => "Try a Bus Airways",
                "VA" => "Vertical Airways",
                _ => throw new ArgumentException("Unknown airline abbreviation."),
            };

            _code = code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_code, _airline, _from, _to, _weekday, _time, _seats, _costPerSeat);
        }
    }
}
