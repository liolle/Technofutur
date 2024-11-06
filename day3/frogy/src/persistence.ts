import {Position} from "@types"	

/**
 * Save player position (in localstorage)
 * @Param position {Position}
 */
export function savePlayerPosition(position:Position){

	const storage = window.localStorage

	try {
		storage.setItem("player_position", JSON.stringify(position))
	}catch (err){
		console.log(err)
	}
}

/**
 * Get player position (from localstorage)
 */
export function getPlayerPosition():Position|null{

	const storage = window.localStorage

	const pos = storage.getItem("player_position")
	if(!pos){return null}

	try {
		const pos_obj = JSON.parse(pos) as Position
		return pos_obj
	}catch (err){

		console.log(err)
		return null
	}


}

