export type Position = {
	x:number,
	y:number
}

export enum Direction {
	up,
	down,
	left,
	right,
}

/**
 * Options for configuring a player in the game.
 * @property id - Unique identifier for the player.
 * @property width - Width of the player (optional).
 * @property height - Height of the player (optional).
 * @property size - Size of the player (optional).
 * @property position - Initial position of the player on the board.
 * @property base_speed - Base speed of the player (optional).
 * @property tyle_set - The tile set associated with the player.
 */
export type PlayerOptions = {
  /** Unique identifier for the player */
  id:string,
  width?: number ,
  height?: number ,
  size?:number,
  position?: Position,
  base_speed?:number,
  tyle_set:TyleSet 
}

export type AnimationInfo = {
  idx:number,
  frames:number
}

export type TyleSet = {
  src:string,
  rows:number,
  cols:number,
  up?: AnimationInfo,
  down?: AnimationInfo ,
  left?: AnimationInfo ,
  right?: AnimationInfo,
}

export type GameOptions = {
  board_width:number,
  board_height:number
}

export type Route = {
  path:string,
  handler:{
    handle:()=>void,
    cleanUp:()=>void
  }
}



