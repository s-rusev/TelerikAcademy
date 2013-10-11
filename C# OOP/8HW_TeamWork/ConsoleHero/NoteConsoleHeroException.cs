using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHero
{
    public class NoteConsoleHeroException : System.ApplicationException
    {
        public NoteConsoleHeroException() : base() { }
        public NoteConsoleHeroException(string message) : base(message) { }
        public NoteConsoleHeroException(string message, System.Exception inner) : base(message, inner) { }
    }
}
