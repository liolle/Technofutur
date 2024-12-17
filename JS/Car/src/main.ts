import CarForm from './Componnents/CarForm/CarFrom'
import NavBar from './Componnents/NavBar/NavBar'
import {  PAGE, registerPageObserver } from './Store'
import './style.css'

function main(){
  const app = document.querySelector("#app") as HTMLDivElement

  const pages = {
    "page_add":(new CarForm).node,
    "page_display":null 

  }

  const nav_bar = (new NavBar()).node

  registerPageObserver((_,current)=>{

    for(const page in pages){
      let element = pages[page as PAGE] 
      if(element && element.parentNode){
        app.removeChild(element)
      }
    } 

    let element = pages[current] 
    if(element){
      app.appendChild(element)
    }

  })

  if(!app){return}
  app.appendChild(pages["page_add"])
  app.appendChild(nav_bar)
}

main()
