using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Log
    {
        public string utilisateur { get; private set; }
        public DateTime date { get; private set; }
        public string description { get; private set; }

        public Log(string description)
        {
            this.utilisateur = Environment.UserName;
            this.date = DateTime.Now;
            this.description = description;
        }
    }
}
