using System;
using System.Collections.Generic;
using ApiUsuarios.Models;
using ApiUsuarios.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    public class PokemonController
    {
        public readonly IPokemonRepository pokemonRepository;
        public PokemonController(IPokemonRepository _pokemonRepository)
        {
            pokemonRepository = _pokemonRepository;
        }

        [HttpGet]
        public Pokemon get() {
            var pokemon = pokemonRepository.get();
            return pokemon;
        }
    }
}