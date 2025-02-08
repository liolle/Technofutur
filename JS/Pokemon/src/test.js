//import {Pokemon} from "./pokemons.js";
let pokemonInfo
let pokemonList = []
let nbPokemon = 151

class Pokemon {
  name 
  constructor(name){
    this.name = name
  }
}

async function getMultiplePokemons(nbPokemon) {
    for (let i = 1; i <= nbPokemon; i++) {
        await getPokemon(i);
    }
}

async function getPokemon(nb) {
    const reponse = await fetch(`https://pokeapi.co/api/v2/pokemon/${nb}`);
    const pokemons = await reponse.json();
    const {id, name, sprites, types } = pokemons;
    const sprite = sprites.front_default;
    const typeNames = types.map(typeInfo => typeInfo.type.name);
    let pokemonInfo = new Pokemon(name);
    // console.log(`Nom: ${name}`);
    // console.log(`Sprite: ${sprite}`);
    // console.log(`Types: ${typeNames.join(', ')}`);
    pokemonList.push(pokemonInfo);
}

getMultiplePokemons(nbPokemon).then(displayPokemons);

//getMultiplePokemons(nbPokemon).then(displayPokemons());

async function displayPokemons() {
    //const container = document.getElementById('pokemon-container');
    //container.innerHTML = '';
    console.log("Je suis dans dislay")
    //console.log(pokemonList)

    pokemonList.forEach(pokemon => {
        console.log(pokemon)
        //const card = document.createElement('div');
        //card.className = 'pokemon-card';
        //const img = document.createElement('img');
        // img.src = pokemon.sprite;
        // img.alt = pokemon.name;
        //const name = document.createElement('h3');
        // name.textContent = pokemon.name;
        //const types = document.createElement('p');
        // types.textContent = `Types: ${pokemon.types.join(', ')}`;
        //card.appendChild(img);
        //card.appendChild(name);
        //card.appendChild(types);
        //container.appendChild(card);
    })
}
/*
async function  f1(){
    await getMultiplePokemons(10)
    displayPokemons()
}

f1()

*/

/*
import {Pokemon} from "./pokemons.js";
let pokemonInfo
let pokemonList = []
let nbPokemon = 151

// récupération des pokémons
//getMultiplePokemons(nbPokemon).then(displayPokemons());
//affichage des pokemons
// for (let i = 1; i <= nbPokemon; i++) {
//     await displayPokemons()
// }

//displayPokemons()
// console.error(pokemonList)
// console.log(pokemonList)

// for (let i = 0; i < pokemonList.length; i++) {
//     console.log(pokemonList[3].name)
// }

async function getMultiplePokemons(nbPokemon) {
    for (let i = 1; i <= nbPokemon; i++) {
        await getPokemon(i);
    }
    //console.log(pokemonList)
}

async function getPokemon(nb) {
    const reponse = await fetch(`https://pokeapi.co/api/v2/pokemon/${nb}`);
    const pokemons = await reponse.json();
    const {id, name, sprites, types } = pokemons;
    const sprite = sprites.front_default;
    const typeNames = types.map(typeInfo => typeInfo.type.name);
    let pokemonInfo = new Pokemon(id, name, typeNames, sprite);
    // console.log(`Nom: ${name}`);
    // console.log(`Sprite: ${sprite}`);
    // console.log(`Types: ${typeNames.join(', ')}`);
    pokemonList.push(pokemonInfo);
}

async function displayPokemons() {
    const container = document.getElementById('pokemon-container');
    container.innerHTML = '';
    console.log("Je suis dans dislay")
    //console.log(pokemonList)

    pokemonList.forEach(pokemon => {
        console.log(pokemon)
        const card = document.createElement('div');
        card.className = 'pokemon-card';
        const img = document.createElement('img');
        // img.src = pokemon.sprite;
        // img.alt = pokemon.name;
        const name = document.createElement('h3');
        // name.textContent = pokemon.name;
        const types = document.createElement('p');
        // types.textContent = `Types: ${pokemon.types.join(', ')}`;
        card.appendChild(img);
        card.appendChild(name);
        card.appendChild(types);
        container.appendChild(card);
    })
}

async function  f1(){
    await getMultiplePokemons()
    await displayPokemons()
}

f1()

//console.log(pokemonList);

*/
