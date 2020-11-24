using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Models
{
    public class PokemonClass
    {
        public List<string> Locations { get; set; } = new List<string>();
        public string SpriteUrl { get; set; }
    }
}
