
export enum PAGE {
  CLOCK ="clock",
  TIMER="timer"
}

type PageCb = (last: PAGE,current:PAGE) => void;
export let page:PAGE = PAGE.CLOCK 
let page_observer:Array<PageCb> = []

export function getCurrentPage(){
  return page
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



