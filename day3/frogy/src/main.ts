import  "./style.css"
import {Posistion,Direction,PlayerOptions,TyleSet} from "@types"
import {Player} from "@/player"
import { Game } from "@/game";


const SQUARE_SIZE = 32
const BOARD_ROWS = 30;
const BOARD_COLS = 40;
const BOARD_WIDTH = BOARD_COLS * SQUARE_SIZE
const BOARD_HEIGHT = BOARD_ROWS * SQUARE_SIZE
const TARGET_FPS = 30

const  canvas = document.querySelector("#canvas") as HTMLCanvasElement

canvas.width = BOARD_WIDTH 
canvas.height = BOARD_HEIGHT

if (!canvas){
  exit(0)
}

const ctx =canvas.getContext('2d')

const player_options:PlayerOptions = {
  id: "default",
  width:32,
  height:32,
  initial_position:{
    x:(BOARD_WIDTH-32)/2 ,
    y:(BOARD_HEIGHT-32)/2 
  } ,
  base_speed: 10,
  tyle_set: {
    src:"fullsheet.png",
    rows:45,
    cols:13,
    animation_up: {idx:8,frames:9},
    animation_left:{idx:9,frames:9},
    animation_down: {idx:10,frames:9},
    animation_right: {idx:11,frames:9},
  }

}
const game_options = {
  board_width : BOARD_WIDTH,
  board_height:BOARD_HEIGHT
}
const game = new Game(ctx,game_options)
const player = new Player(ctx,player_options)

game.addPlayer(player)
game.launch()

