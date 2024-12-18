class Position {
  row
  col

  constructor(row:number, col:number){
    this.row = row
    this.col = col
  }

  addPoint(p:Position){
    this.row += p.row
    this.col += p.col
  }

  add(row:number, col:number){
    this.row += row  
    this.col += col  
  }

  normalise(rows:number, cols:number){
    this.row = this.row % rows
    this.col = this.col % cols

    if(this.row <0){this.row += rows}
    if(this.col <0){this.col += cols}
  }

  setPoint(p:Position){
    this.row = p.row
    this.col = p.col
  }

  set(row:number,col:number){
    this.row = row
    this.col = col
  }
  
}

export default Position
