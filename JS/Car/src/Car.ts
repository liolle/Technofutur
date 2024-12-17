class Car {
  mark:string
  model:string
  power:number
  year:Date
  fuel_tank_capacity:number
  fuel_consumption:number

  constructor(
    mark:string,
    model:string,
    power:number,
    year:Date,
    fuel_tank_capacity:number,
    fuel_consomption:number,
  ){
    this.mark =mark
    this.model =model
    this.power = power
    this.year =year
    this.fuel_tank_capacity = fuel_tank_capacity
    this.fuel_consumption = fuel_consomption
  }

}

export default Car
