import { createEffect, createSignal, For, onMount, type Component } from 'solid-js';

const UNIT_PER_PAGE = 20

export const [getPage,setPage] = createSignal(0)
export const [pokemons,setPokemon] = createSignal<Pokemon[]>([])

async function fetchPokemon(id:number):Promise<Pokemon>{
  try {
    let response = await fetch(`https://pokeapi.co/api/v2/pokemon/${id}`)
    let data = await response.json()
    let name = data["name"]
    
    return {
      name:name,
      image:data["sprites"]["back_default"],
      id:id
    }
  } catch (error) {
    console.error(error)
  }
}

async function fetchPokemons(){
  const api_calls:Promise<Pokemon>[] = []

  for(let i=1 ;i<=20;i++){
    let idx = getPage()*UNIT_PER_PAGE +i
    api_calls.push(fetchPokemon(idx))
  }

  Promise.allSettled(api_calls).then((results) => {
    const pokemons = results
    .filter((result) => result.status === "fulfilled")
    .map((result) => result.value);
    setPokemon(pokemons)
  });
}

const App: Component = () => {

  onMount(async()=>{
    fetchPokemons()
  })

  createEffect(()=>{
    let page = getPage()
    fetchPokemons()
  })


  return (

    <div class=" flex flex-wrap justify-center gap-[1rem] h-screen w-full bg-neutral-700 p-2 overflow-y-scroll">
      <For each={pokemons()} >
        {(pokemon) => <PokemonCard name={pokemon.name} id={pokemon.id} image={pokemon.image} />}
      </For>
      <Controller/>
    </div>
  );
};



const PokemonCard: Component<Pokemon> = (props:Pokemon)=>{

  return (
    <div class={`h-[300px] w-[200px] border-[1px] border-[green] w-fit flex align-center justify-center relative  rounded-lg select-none `}
    >
      <img class="object-contain object-center bg-no-repeat h-full" src={props.image}/>
      <span class="absolute bottom-[1rem] text-mono text-lg text-neutral-200 font-bold">{props.name}</span>
      <div class="absolute top-[1rem] right-[1rem] text-mono text-lg text-neutral-200 font-bold rounded-full">{props.id}</div>
    </div>
  )
}

const Controller: Component = ()=>{

  function prev(){
    setPage(prev=>Math.max(60,prev-1))
  }

  function next(){
    setPage(prev=>Math.min(60,prev+1))
  }


  return (
    <div class="absolute bottom-[2rem] left-[2rem] flex justify-between gap border-[1px] border-neutral-200 p-1 rounded-lg text-mono font-bold text-lg select-none">
      <button onClick={debounce(prev)} class=" flex justify-center align-center px-[1rem] py-[.5rem]">
        {'<'} 
      </button>
      <span class="px-[1rem] py-[.5rem]">{getPage()+1}</span>
      <button onClick={debounce(next)} class=" flex justify-center align-center px-[1rem] py-[.5rem]">
        {'>'} 
      </button>
    </div>
  )
}

interface Pokemon {
  name:string
  image:string
  id:number
}

/**
 * Limit the function call frequenct at 1 once every timeout ms 
 * @param {(...args:)=>void} cb 
 * @param {number} timeout timeout between each function call.
 * */
export function debounce(cb: (...args: any) => void, timeout = 300) {
  let timer: any = null;
  return (...args: any) => {
    clearTimeout(timer);

    timer = setTimeout(() => {
      cb(...args);
    }, timeout);
  };
}

export default App;
