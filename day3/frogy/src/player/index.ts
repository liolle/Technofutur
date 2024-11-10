import { PlayerOptions, Position, Direction, TyleSet } from "@type";
export class Player {
  private listenersCb:(()=>void)[] = []

  id = "default"
  position:Position = {
    x:0,
    y:0
  }
  speed =  10
  base_speed = 10
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

    this.base_speed = options.base_speed ?? 10
    if(options.tyle_set){
      this.tyle_set = options.tyle_set 
      this.tyle_image = new Image()
      this.tyle_image.src = options.tyle_set.src

    }
  }

  #computDirection (){

    const dir_arr = [
      {direction:"down",speed:this.v_down},
      {direction:"up",speed:this.v_up},
      {direction:"left",speed:this.v_left},
      {direction:"right",speed:this.v_right},
    ]

    dir_arr.sort((a,b)=>b.speed-a.speed)
    if(dir_arr[0].speed>0){
      this.last_direction = dir_arr[0].direction 
    }
  }

  draw() {
    
    if(this.tyle_set && this.tyle_image){
      let tyle_idx = 0
      switch (this.last_direction) {
        case "up":
          tyle_idx = this.tyle_set.animation_up.idx ?? 0
          break;
        case "down":
          tyle_idx = this.tyle_set.animation_down.idx ?? 0
          break;
        case "left":
          tyle_idx = this.tyle_set.animation_left.idx ?? 0
          break;
        case "right":
          tyle_idx = this.tyle_set.animation_right.idx ?? 0
          break;

        default:
          break;
      }
      this.context.drawImage(this.tyle_image,0,tyle_idx * this.height,64,64,this.position.x,this.position.y,64,64)
    }



  }

  update(dt:number){
    // checking border
    const x = Math.max(Math.min(this.position.x+(this.v_right-this.v_left),Infinity- this.width),0)
    const y = Math.max(Math.min(this.position.y+(this.v_down-this.v_up),Infinity - this.height),0)

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
    this.#computDirection()
  }

  free(){
    for(const cb of this.listenersCb){
      cb()
    }
  }

}

