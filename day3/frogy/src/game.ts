import {savePlayerPosition,getPlayerPosition} from "@/persistence"
import {Position} from "@types"

const SQUARE_SIZE = 50
const BOARD_ROWS = 10;
const BOARD_COLS = 10;
const SEPARATOR_WIDTH = 2
const BOARD_WIDTH = BOARD_ROWS * SQUARE_SIZE + (BOARD_ROWS-1 * SEPARATOR_WIDTH)
const BOARD_HEIGHT = BOARD_COLS * SQUARE_SIZE + (BOARD_COLS-1 * SEPARATOR_WIDTH)

const  canvas = document.querySelector("#canvas") as HTMLCanvasElement

canvas.width = BOARD_WIDTH 
canvas.height = BOARD_HEIGHT

if (!canvas){
	exit(0)
}

function drawBoard(context:RenderingContext2D){
	//clear the canvas	
	context.clearRect(0,0,BOARD_WIDTH,BOARD_HEIGHT)

	//Draw bord
	for (let row = 0; row < BOARD_ROWS; row++) {
		for (let col = 0; col < BOARD_COLS; col++) {
			// Calculate x and y positions, including space for separators
			const x = col * (SQUARE_SIZE + SEPARATOR_WIDTH);
			const y = row * (SQUARE_SIZE + SEPARATOR_WIDTH);

			// Fill each cell with a color (alternating colors for a checkerboard effect)
			context.fillStyle = "#ffffff";
			context.fillRect(x, y, SQUARE_SIZE, SQUARE_SIZE);
		}
	} 
}

const ctx =canvas.getContext('2d')
drawBoard(ctx)
