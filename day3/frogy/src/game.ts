import {savePlayerPosition,getPlayerPosition} from "@/persistence"
import {Position} from "@types"


const  app = document.querySelector("#app")

const pos:Position =  {
	x:0,
	y:2
}

savePlayerPosition(pos)
console.log(getPlayerPosition()) 
