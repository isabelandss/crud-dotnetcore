using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ApiUsuarios.Models;
using ApiUsuarios.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiUsuarios.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        Pokemon pokemon;
        HttpService http;
        public PokemonRepository(HttpService _http)
        {
            http = _http;
        }

        public Pokemon get()
        {
            string url = "http://pokeapi.co/api/v2/pokemon/1";
            var resultado = http.get(url);

            pokemon = new Pokemon();

            pokemon.id = resultado.id;
            pokemon.name = resultado.name;
            pokemon.height = resultado.height;
            pokemon.weight = resultado.weight;

            return pokemon;
        }
    }
}