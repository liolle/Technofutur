export type Posistion = {
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
  position: Posistion|undefined,
  base_speed:number|undefined,
  tyle_set:TyleSet | undefined
}

export type AnimationInfo = {
  idx:number,
  frames:number
}

export type TyleSet = {
  src:string,
  rows:number,
  cols:number,
  animation_up: AnimationInfo|undefined 
  animation_down: AnimationInfo|undefined ,
  animation_left: AnimationInfo|undefined ,
  animation_right: AnimationInfo|undefined,
}

export type GameOptions = {
  board_width:number,
  board_height:number
}
