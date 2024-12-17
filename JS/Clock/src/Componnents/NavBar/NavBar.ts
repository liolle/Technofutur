import { getCurrentPage, PAGE, registerPageObserver, updatePage } from '../../Store'
import './NavBar.css'

class NavBar {

  _node:HTMLDivElement= document.createElement("div")

  clock_btn = document.createElement("button") as HTMLButtonElement
  timer_btn = document.createElement("button") as HTMLButtonElement
  
  constructor(){
    this._node.classList.add('nav')

    this.clock_btn.classList.add('bnt')
    this.clock_btn.textContent = "Clock"
    this.timer_btn.classList.add('bnt')
    this.timer_btn.textContent = "Timer"


    this.clock_btn.addEventListener('click',()=>{
      updatePage(PAGE.CLOCK) 
    })

    this.timer_btn.addEventListener('click',()=>{
      updatePage(PAGE.TIMER) 
    })

    this._node.appendChild(this.clock_btn)
    this._node.appendChild(this.timer_btn)
    this.#setActive()

    registerPageObserver(this.#setActive.bind(this))
  }

  #setActive(){
    let page = getCurrentPage()
    
    this.clock_btn.classList.remove("active")
    this.timer_btn.classList.remove("active")
    switch (page) {
      case PAGE.CLOCK:
        this.clock_btn.classList.add("active")
        break;
      case PAGE.TIMER:
        this.timer_btn.classList.add("active")
        break;
      default:
        break;
    }
  }

  get node(){
    return this._node
  }
}


export default NavBar
