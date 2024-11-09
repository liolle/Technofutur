import {Position,Direction} from "@types"

const SQUARE_SIZE = 50
const BOARD_ROWS = 15;
const BOARD_COLS = 20;
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

class Player {
	position:Position = {
		x:BOARD_WIDTH/2,
		y:BOARD_HEIGHT/2
	}
	cur_position:Position = {
		x:BOARD_WIDTH/2,
		y:BOARD_HEIGHT/2
	}
	speed =  50
	v_up = 0
	v_down = 0
	v_left = 0
	v_right = 0
	base_speed = 25
	width = 50
	height = 50
	context:RenderingContext2D

	constructor(context:RenderingContext2D){
		this.context = context


		// setup Positions:
		this.position.x -= this.width/2
		this.position.y -= this.height/2
		this.cur_position.x = this.position.x
		this.cur_position.y = this.position.y
	}

	draw() {
		const ctx = this.context
		const pos = this.position

		ctx.fillStyle = 'blue'
		ctx.fillRect(pos.x,pos.y,this.width,this.height)
	}

	update(){
		const x = Math.max(Math.min(this.position.x+(this.v_right-this.v_left)/TARGET_FPS,BOARD_WIDTH - this.width),0)
		const y = Math.max(Math.min(this.position.y+(this.v_down-this.v_up)/TARGET_FPS,BOARD_HEIGHT - this.height),0)

		this.position.x = x 
		this.position.y = y 
	}

	stopPlayer (){
		this.cur_position.y = this.position.y
		this.cur_position.x = this.position.x
	}

	move(direction:Direction){
		switch (direction) {
			case "left":
				this.v_left =  this.speed
			break
			case "right":
				this.v_right = this.speed
			break
			case "up":
				this.v_up = this.speed
			break
			case "down":
				this.v_down = this.speed
			break
			default:
				break
		}
	}

	cancelMove(direction:Direction){
		switch (direction) {
			case "left":
				this.v_left = 0 
			break
			case "right":
				this.v_right = 0
			break
			case "up":
				this.v_up = 0 
			break
			case "down":
				this.v_down = 0
			break
			default:
				break
		}
	}

}
const player = new Player(ctx)

document.addEventListener('keydown', (event) => {

	switch (event.key) {
		case 'z': // Move up
			player.move("up")
		break;
		case 'q': // Move left
			player.move("left")
		break;
		case 's': // Move down
			player.move("down")
		break;
		case 'd': // Move right
			player.move("right")
		break;
		default:
			break;
	}
});

document.addEventListener('keyup', (event) => {

	switch (event.key) {
		case 'z':
			player.cancelMove("up")
		break;
		case 's': 
			player.cancelMove("down")
		break;
		case 'q':
			player.cancelMove("left")
		break;
		case 'd':
			player.cancelMove("right")
		break;
		default:
			break;
	}
});

function animate(){
	if (!ctx){
		return
	}
	ctx.clearRect(0,0,BOARD_WIDTH,BOARD_HEIGHT)
	player.update()	
	player.draw()
	requestAnimationFrame(animate)	
}


animate()
