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
	speed =  20
	width = 50
	height = 50
	context:RenderingContext2D
	last_direction:Direction|null = null

	constructor(context:RenderingContext2D){
		this.context = context
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
		const dx = this.cur_position.x - this.position.x 
		const dy = this.cur_position.y - this.position.y 
		const x = Math.max(Math.min(this.position.x+dx/TARGET_FPS,BOARD_WIDTH - this.width),0)
		const y = Math.max(Math.min(this.position.y+dy/TARGET_FPS,BOARD_HEIGHT - this.height),0)

		this.position.x = x 
		this.position.y = y 
	}

	stopPlayer (){
		this.cur_position.y = this.position.y
		this.cur_position.x = this.position.x
		requestAnimationFrame(()=>{})
	}

	move(direction:Direction){
		let burst = 0
		if (this.last_direction != direction){
			burst += 2*this.speed
		}
		switch (direction) {
			case "left":
				this.cur_position.x = Math.min(this.cur_position.x, this.position.x)
				this.cur_position.x -= this.speed + burst

				break
			case "right":
				this.cur_position.x = Math.max(this.cur_position.x, this.position.x)
				this.cur_position.x += this.speed + burst
				break
			case "up":
				this.cur_position.y = Math.min(this.cur_position.y, this.position.y)
				this.cur_position.y -= this.speed + burst
				break
			case "down":
				this.cur_position.y = Math.max(this.cur_position.y, this.position.y)
				this.cur_position.y += this.speed + burst
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
		case 'z': // Move up
		case 'q': // Move left
		case 's': // Move down
		case 'd': // Move right
			player.stopPlayer()
			break
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
