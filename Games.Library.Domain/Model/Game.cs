using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Library.Domain.Model
{
    public class Game
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Release { get; set; }
        public string Platforms { get; set; }
    }
}
