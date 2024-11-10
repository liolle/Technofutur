import { GameOptions } from "@types";
import { Player } from "../player";

export class Game {
  _board_width = 512
  _board_height = 512
  _context:RenderingContext2D|null = null
  _players:Player[] = []
  private prev_timestamp = 0


  constructor(context:RenderingContext2D,options:GameOptions) {
    this._board_width = options.board_width
    this._board_height = options.board_height
    this._context = context

  }

  launch(){
    this.#animate(this.prev_timestamp)
  }

  addPlayer(player:Player){
    this._players.push(player)
  }

  removePlayer(id:string){
    this._players.filter((player)=>player.id != id)
  }

  get context() {
    return this._context
  } 

  get board_width() {
    return this._board_width
  }

  get board_height() {
    return this._board_height
  }
 

  #animate(timestamp){
    const elapsed = timestamp - this.prev_timestamp;
    
    if (!this.context){
      return
    }
    this._context.clearRect(0,0,this.board_width,this.board_height)
    for(const player of this._players){
      player.update(elapsed)
      player.draw()
    }

    requestAnimationFrame(this.#animate.bind(this))

  }
}
