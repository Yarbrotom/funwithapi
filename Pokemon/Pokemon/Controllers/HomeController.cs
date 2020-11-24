using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string name)
        {
            if(name != null)
            {
                PokemonClass pokemon = await GetPokemonInfo(name);
                return View(pokemon);
            }
            return View();
        }

        public async Task<PokemonClass> GetPokemonInfo(string targetPokemon)
        {
            PokemonClass pokemon = new PokemonClass();

            string location = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/" + targetPokemon + "/encounters");
            string sprite = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon-form/" + targetPokemon);
            
            var pokemonLocations = JsonConvert.DeserializeObject<dynamic>(location);
            var pokemonImage = JsonConvert.DeserializeObject<dynamic>(sprite);

            foreach(var pokemonLocation in pokemonLocations)
            {
                pokemon.Locations.Add(pokemonLocation.location_area.name.ToString());
            }

            pokemon.SpriteUrl = pokemonImage.sprites.front_default.ToString();
            return pokemon;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
