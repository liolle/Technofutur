import { PlayerOptions, Position, Direction, TyleSet } from "@type";
export class Player {
  private listenersCb:(()=>void)[] = []
  private frameX = 0
  private frameY = 0
  private frameMax = 1
  private draw_interval = 60
  private last_drawn = 0
  private size = 1

  id = "default"
  position:Position = {
    x:0,
    y:0
  }
  speed =  8
  base_speed = 8
  v_up = 0
  v_down = 0
  v_left = 0
  v_right = 0
  width = 64
  height = 64
  context:RenderingContext2D
  last_direction:Direction = "down"
  tyle_set:TyleSet | null
  tyle_image:HTMLImageElement|null = null

  constructor(context:RenderingContext2D, options:PlayerOptions){
    this.context = context

    // setup options:
    this.#setUpOptions(options)
    this.#setUpListeners()
  }

  #setUpListeners(){
    const keyDownCb = ()=>{
      switch (event.key) {
        case 'z': // Move up
          this.move("up")
          break;
        case 'q': // Move left
          this.move("left")
          break;
        case 's': // Move down
          this.move("down")
          break;
        case 'd': // Move right
          this.move("right")
          break;
        default:
          break;
      }

    }

    const keyUpCb = ()=>{
      switch (event.key) {
        case 'z':
          this.cancelMove("up")
          break;
        case 's': 
          this.cancelMove("down")
          break;
        case 'q':
          this.cancelMove("left")
          break;
        case 'd':
          this.cancelMove("right")
          break;
        default:
          break;
      }

    }
    document.addEventListener('keydown', keyDownCb);
    document.addEventListener('keyup', keyUpCb);

    this.listenersCb.push(()=>{
      document.removeEventListener('keyup',keyUpCb)
      document.removeEventListener('keydown', keyDownCb)
    })
  }

  #setUpOptions(options:PlayerOptions){
    this.id = options.id
    this.position = options.initial_position ?? {
      x:0,
      y:0
    }
    this.width = options.width || 64
    this.height = options.height || 64
    this.size = options.size || 1

    this.base_speed = options.base_speed ?? 10
    if(options.tyle_set){
      this.tyle_set = options.tyle_set 
      this.tyle_image = new Image()
      this.tyle_image.src = options.tyle_set.src
      this.frameY = this.tyle_set[this.last_direction].idx || 0
      this.frameMax = this.tyle_set[this.last_direction].frames || 1

    }
  }

  

  #computDirection (rotate=true){

    let direction = this.last_direction
    
    const dx = this.v_right - this.v_left
    const dy = this.v_down-this.v_up
    const d_alpha = Math.abs(dx)+Math.abs(dy) 

    if (d_alpha != 0) {
      if(Math.abs(dx)>Math.abs(dy)){
        direction = dx>0 ? "right":"left"
      }else {
        direction = dy>0? "down":"up"
      }
    }

    if(d_alpha > 0){
    this.last_direction = direction
      this.isMoving = true
      this.frameMax = this.tyle_set[direction].frames
      this.frameY = this.tyle_set[direction].idx
    }else {
      this.frameX=0
      this.isMoving = false
    }
  }

  draw(dt:number) {
    this.#update(dt)
    this.#animate(dt)
    this.context.drawImage(this.tyle_image,this.frameX * this.width,this.frameY * this.height,64,64,this.position.x,this.position.y,this.width*this.size,this.height*this.size)
  }

  #animate(dt:number){
    // TODO (find a better formula to include the the character speed in the draw_interval)
    this.draw_interval = Math.ceil(2**(7-Math.ceil(this.speed/(this.width*dt)))) 


    if (this.last_drawn >= this.draw_interval){
      this.last_drawn = 0
      if(this.isMoving){
        this.frameX = (this.frameX+1)%this.frameMax
      }
    }else {
      this.last_drawn += dt
    }
  }

  #update(dt:number){
    // checking border
    const x = Math.max(Math.min(this.position.x+(this.v_right-this.v_left) * dt/32,Infinity- this.width),0)
    const y = Math.max(Math.min(this.position.y+(this.v_down-this.v_up) * dt/32,Infinity - this.height),0)

    this.position.x = x 
    this.position.y = y 
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
    this.#computDirection()
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
    this.#computDirection(false)
  }

  free(){
    for(const cb of this.listenersCb){
      cb()
    }
  }

}

