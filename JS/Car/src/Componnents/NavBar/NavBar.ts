import { getCurrentPage, PAGE, registerPageObserver, updatePage } from '../../Store'
import './NavBar.css'

class NavBar {

  _node:HTMLDivElement= document.createElement("div")

  edit_btn = document.createElement("button") as HTMLButtonElement
  display_btn = document.createElement("button") as HTMLButtonElement
  constructor(){
    this._node.classList.add('nav')

    this.edit_btn.classList.add('bnt')
    this.edit_btn.textContent = "Edit"
    this.display_btn.classList.add('bnt')
    this.display_btn.textContent = "Display"


    this.edit_btn.addEventListener('click',()=>{
      updatePage(PAGE.ADD) 
    })

    this.display_btn.addEventListener('click',()=>{
      updatePage(PAGE.DISPLAY) 
    })

    this._node.appendChild(this.edit_btn)
    this._node.appendChild(this.display_btn)
    this.#setActive()

    registerPageObserver(this.#setActive.bind(this))
  }

  #setActive(){
    let page = getCurrentPage()
    
    this.edit_btn.classList.remove("active")
    this.display_btn.classList.remove("active")
    switch (page) {
      case PAGE.ADD:
        this.edit_btn.classList.add("active")
        break;
      case PAGE.DISPLAY:
        this.display_btn.classList.add("active")
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
