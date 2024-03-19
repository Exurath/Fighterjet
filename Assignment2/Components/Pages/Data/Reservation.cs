using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Components.Pages.Data
{
    internal class Reservation
    {
        public const int RECORD_SIZE = 201;

        private string _code;
        private string _flightCode;
        private string _airline;
        private string _name;
        private string _citizenship;
        private double _cost;
        private string _active;
        private string _reservationCode;
        private Flight _flight;

        public Reservation()
        {
        }

        public Reservation(string code, string flightCode, string airline, double cost, string name, string citizenship, string active)
        {
            _code = code;
            _flightCode = flightCode;
            _airline = airline;
            _name = name;
            _citizenship = citizenship;
            _cost = cost;
            _active = active;
        }

        public Reservation(string reservationCode, Flight flight, string name, string citizenship)
        {
            _reservationCode = reservationCode;
            _flight = flight;
            _name = name;
            _citizenship = citizenship;
        }

        public string Code { get => _code; set => _code = value; }
        public string FlightCode { get => _flightCode; set => _flightCode = value; }
        public string Airline { get => _airline; set => _airline = value; }
        public string Name { get => _name; set => _name = value; }
        public string Citizenship { get => _citizenship; set => _citizenship = value; }
        public double Cost { get => _cost; set => _cost = value; }
        public string Active { get => _active; set => _active = value; }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            _name = name;
        }

        public void SetCitizenship(string citizenship)
        {
            if (string.IsNullOrEmpty(citizenship))
            {
                throw new Exception("Invalid citizenship");
            }

            _citizenship = citizenship;
        }

        public override string ToString()
        {
            return $"{Code}, {FlightCode}, {Airline}, {Cost}, {Name}, {Citizenship}, {Active}";
        }
    }
}

