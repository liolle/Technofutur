
abstract class Player {
  private firsname:string
  private lastname:string

  constructor(firsname:string,lastname:string){}
}

class Hero extends Player {
  constructor(firsname:string,lastname:string){
    super(firsname,lastname)
  }
}

type PNJ_TYPE = "police" | "firefighter"

class PNJ extends Player {

  private _type:PNJ_TYPE

  constructor(type:PNJ_TYPE,firsname:string,lastname:string){
    super(firsname,lastname)
    this._type = type
  }

  get type(){
    return this._type
  }
}

abstract class Vehicule {
  private _driver:Player|null

  constructor(){}

  get driver(){
    return this._driver
  }

  set diver(player:Player){
    this._driver = player
  }
}


abstract class Weapon {
  protected _fire_rate: number; 
  protected _current_ammunition: number; 
  protected _max_ammunition: number; 

  constructor(fire_rate: number, max_ammunition: number) {
    this._fire_rate = fire_rate;
    this._max_ammunition = max_ammunition;
    this._current_ammunition = max_ammunition; 
  }

  abstract fire(): void;
  abstract reload(): void;

  get current_ammunition(): number {
    return this._current_ammunition
  }

  get fire_rate(): number {
    return this._fire_rate;
  }

  get max_ammunition():number {
    return this._max_ammunition
  }
}

class Gun extends Weapon {
  constructor(fire_rate: number, max_ammunition: number) {
    super(fire_rate, max_ammunition);
  }

  fire(): void {
    if (this._current_ammunition > 0) {
      console.log("Bang! 🔫");
      this._current_ammunition; 
      console.log(`Remaining ammo: ${this.current_ammunition}`);
    } else {
      console.log("Out of ammo! Reload your weapon.");
    }
  }

  reload(): void {
    console.log("Reloading...");
    this._current_ammunition = this._max_ammunition; 
    console.log(`Ammo reloaded. Current ammo: ${this.current_ammunition}`);
  }
}


