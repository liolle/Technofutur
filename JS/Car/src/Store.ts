import Car from "./Car";

export enum PAGE {
  ADD ="page_add",
  DISPLAY="page_display"
}

type PageCb = (last: PAGE,current:PAGE) => void;
export let page:PAGE = PAGE.ADD  
let page_observer:Array<PageCb> = []

let currentCar:Car|null = null

export function getCurrentCar(){
  return currentCar
}

export function getCurrentPage(){
  return page
}

export function setCurrentCar(car:Car){
  currentCar = car 
}

export function registerPageObserver(cb:PageCb){
  page_observer.push(cb)
}

export function updatePage(p:PAGE){
  
  let last = page
  page = p
  for (const cb of page_observer){
    cb(last,page)
  }
}



