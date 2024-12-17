import "./Clock.css"
class Clock {
  private _node = document.createElement("div")
  private interval:number 
  private span:HTMLSpanElement = document.createElement("span")

  constructor(){
    this.#setup()
    this.interval = setInterval(()=>{
      this.#loop()
    },1000)
  }

  #setup(){

    this._node.classList.add("clock")
    this._node.appendChild(this.span)

    window.addEventListener("unload",()=>{
      this.clear()
    })
  }

  #loop(){
    this.#updateDisplay()
  }

  #updateDisplay(){
    let date =new Date(Date.now()) 
    const hours = String(date.getHours()).padStart(2, '0'); 
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');
    this.span.textContent = `${hours} : ${minutes} : ${seconds}` 
  }

  get node(){
    return this._node
  }

  clear(){
    clearInterval(this.interval)
  }
}

export default Clock
