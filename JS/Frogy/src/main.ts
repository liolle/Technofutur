import Position from './Position/Position'
import './style.css'

const ROWS = 10
const COLS = 10

const FLY = document.createElement('div')
FLY.style.backgroundImage = `url('fly.svg')`
FLY.classList.add("insect")

let table:HTMLElement[][] = []
let score = 0
let last_position = new Position(0,0)
let position = new Position(0,0)

const frog_img = document.createElement("img")
frog_img.src = "bat_pepe.png"
frog_img.classList.add("pepe")

let arr = document.createElement("div")
arr.style.backgroundImage = `url('https://i.gifer.com/origin/6c/6c1aa59dc33011ddc7d6ab19d8226d20_w200.gif')` 
arr.classList.add('arr')

let score_div = document.createElement("div")
score_div.textContent = "0"
score_div.classList.add("score")

document.body.appendChild(score_div)

for (let i = 0; i < ROWS; i++) {
  let row = document.createElement("div")
  row.classList.add('row')
  let r:HTMLElement[] = []
  for (let j = 0; j < COLS; j++) {
    let cell = document.createElement("div")
    cell.classList.add('cell')

    cell.addEventListener('click',()=>{
      last_position.setPoint(position)
      position.add(i,j)
      position.normalise(ROWS,COLS)
      updateCell() 
    })

    row.appendChild(cell)
    r.push(cell)
  } 
  arr.appendChild(row)
  table.push(r)
}
/*
function inBound(r:number,c:number) {
  return r>=0 && c>=0 && r<ROWS && c<COLS 
}
*/ 

document.body.appendChild(arr)
document.addEventListener('keydown',(e)=>{

  last_position.setPoint(position)
  switch (e.key) {
    case "z":
    case "ArrowUp":
      position.add(-1,0)
      break
    case "s":
    case "ArrowDown":
      position.add(1,0)
      break
    case "q":
    case "ArrowLeft":
      position.add(0,-1)
      break
    case "d":
    case "ArrowRight":
      position.add(0,1)
      break
    default:
      break;
  }
  position.normalise(ROWS,COLS)
  updateCell()
})

function spawnInsects(){
  let r = Math.floor(Math.random()*ROWS)
  let c = Math.floor(Math.random()*COLS)

  while (r == position.row && c == position.col) {
    r = Math.floor(Math.random()*ROWS)
    c = Math.floor(Math.random()*COLS)
  }

  let cell = table[r][c]

  for(const child of cell.children){
    cell.removeChild(child)
  }
  let elem = FLY.cloneNode(true) 

  cell.appendChild(elem)

  setTimeout(()=>{
    if( elem.parentNode){
    elem.parentNode.removeChild(elem)
    }
  },Math.floor(Math.random()*2000)+1000)
}

function updateScore(method:string,amount:number){
  switch (method) {
    case "add":
      score += amount
      break;
    case "remove":
      score = Math.max(0,score-amount)
      break;
    default:
      break;
  }
  score_div.textContent = score.toString()
}

function updateCell(){
  let last =table[last_position.row][last_position.col] 
  let n_cell = table[position.row][position.col] 
  for(const child of n_cell.children){
    updateScore('add',1)
    n_cell.removeChild(child)
  }
  last.style.backgroundImage = ""
  n_cell.style.backgroundImage = `url('bat_pepe.png')`

}

updateCell()

function drawInsect(){
  spawnInsects() 
  setTimeout(()=>{
    requestAnimationFrame(drawInsect)
  },Math.floor(Math.random()*5000)+2000)
}

drawInsect()
