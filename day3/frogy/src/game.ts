import {savePlayerPosition,getPlayerPosition} from "@/persistence"
import {Position} from "@types"

const SQUARE_SIZE = 50
const BOARD_ROWS = 15;
const BOARD_COLS = 20;
const SEPARATOR_WIDTH = 2
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
	last_direction = ""
	constructor(context:RenderingContext2D){
		this.context = context
		this.height = 50
		this.width = 50
		this.position.x -= this.width/2
		this.position.y -= this.height/2
		this.speed = 20
		this.cur_position = {...this.position}
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

	moveDown(){
		this.cur_position.y = Math.max(this.cur_position.y, this.position.y)
		this.cur_position.y+=this.speed
		 if(this.last_direction != "down"){
                        this.cur_position.y+= this.speed *2
                        this.last_direction = "down"
                }

	}
	moveUp(){
		this.cur_position.y = Math.min(this.cur_position.y, this.position.y)
		this.cur_position.y-=this.speed
		 if(this.last_direction != "up"){
                        this.cur_position.y-= this.speed *2
                        this.last_direction = "up"
                }

	}

	moveLeft(){
		this.cur_position.x = Math.min(this.cur_position.x, this.position.x)
		this.cur_position.x-=this.speed
		if(this.last_direction != "left"){
                        this.cur_position.x-= this.speed *2
			this.last_direction = "left"
                }

	}

	moveRight(){
		this.cur_position.x = Math.max(this.cur_position.x, this.position.x)
		this.cur_position.x+=this.speed
		if(this.last_direction != "right"){
			this.cur_position.x+= this.speed * 2
			this.last_direction = "right"
		}
	}


}


const player = new Player(ctx)

document.addEventListener('keydown', (event) => {
	switch (event.key) {
		case 'z': // Move up
			player.moveUp()	
		break;
		case 'q': // Move left
			player.moveLeft()	
		break;
		case 's': // Move down
			player.moveDown()	
		break;
		case 'd': // Move right
			player.moveRight()	
		break;
		default:
			break;
	}
});

function animate(){
	ctx.clearRect(0,0,BOARD_WIDTH,BOARD_HEIGHT)
	player.update()	
	player.draw()
	requestAnimationFrame(animate)	
}


animate()
