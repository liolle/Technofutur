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

export type PlayerOptions = {
  id:string,
  width: number | undefined,
  height: number | undefined,
  size:number|undefined,
  position: Position|undefined,
  base_speed:number|undefined,
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
  up: AnimationInfo|undefined,
  down: AnimationInfo|undefined ,
  left: AnimationInfo|undefined ,
  right: AnimationInfo|undefined,
}

export type GameOptions = {
  board_width:number,
  board_height:number
}
