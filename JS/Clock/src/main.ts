import Clock from './Componnents/Clock/Clock'
import NavBar from './Componnents/NavBar/NavBar'
import Timer from './Componnents/Timer/Timer'
import { PAGE, registerPageObserver } from './Store'
import './style.css'


function main(){
  const APP = document.querySelector("#app")
  if(!APP){return}

  const pages = {
    "clock":new Clock(),
    "timer":new Timer() 

  }

  const nav_bar = new NavBar()

  registerPageObserver((_,current)=>{

    for(const page in pages){
      let element = pages[page as PAGE] 
      if(element && element.node.parentNode){
        APP.removeChild(element.node)
      }
    } 

    let element = pages[current] 
    if(element){
      APP.appendChild(element.node)
    }

  })

  APP.appendChild(pages["clock"].node)
  APP.appendChild(pages["timer"].dialog.node)
  APP.appendChild(nav_bar.node)
}


main()
