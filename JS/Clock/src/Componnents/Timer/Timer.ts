import './Timer.css'
enum TIMER_STATE {
  "RUNNING", 
  "STOPED"
} 

class Timer {
  private _node = document.createElement("div")
  private interval =0 
  private span:HTMLSpanElement = document.createElement("span")
  private _timer = 0
  private state = TIMER_STATE.STOPED
  private _dialog:Dialog
  private stop_btn = document.createElement("button")
  private start_btn = document.createElement("button")
  private row1 = document.createElement("div")
  private row2 = document.createElement("div")

  constructor(){
    this.#setup()
    this._dialog = new Dialog(this.#onDialogSubmit.bind(this))
    this.span.addEventListener("click",this.#onClickEdit.bind(this))
  }

  #setup(){
    this._node.classList.add("timer")
    this.row1.appendChild(this.span)
    this._node.appendChild(this.row1)
    this.#updateDisplay()
    this.#setButton()

    window.addEventListener("unload",()=>{
      this.clear()
    })
  }

  #onClickEdit(){
    this._dialog.show()
  }

  #onDialogSubmit(ev:SubmitEvent){
    ev.preventDefault()
    let target = ev.target as HTMLFormElement 
    if(!target){return}
    let data = new FormData(target)

    console.log(data.get("Timer"));
    this._dialog.close()
    
    let d = data.get("Timer") as string 
    if(d){
      this.stop()
      this.timer = parseInt(d) 
      this.#updateDisplay()
      console.log(this);
      
    }
  }

  #setButton(){
    this.stop_btn.classList.add("t-btn")
    this.stop_btn.textContent = "Stop"

    this.start_btn.classList.add("t-btn")
    this.start_btn.textContent = "Start"

        this.stop_btn.addEventListener('click',this.stop.bind(this))
    this.start_btn.addEventListener('click',this.start.bind(this))


    this.row2.appendChild(this.start_btn)
    this.row2.appendChild(this.stop_btn)
    this._node.appendChild(this.row2)
  }


  #tick(){
    this._timer  = Math.max(0,this._timer-1)
    this.#updateDisplay()
  }

  start(){
    if(this._timer == 0) return 
    switch(this.state){
      case TIMER_STATE.STOPED:
        this.interval = setInterval(this.#tick.bind(this),1000)
        break
      default:
        break
    }
    this.state = TIMER_STATE.RUNNING
  }

  stop(){
    console.log(this.state);
    
    switch(this.state){
      case TIMER_STATE.RUNNING:
        clearInterval(this.interval)
        break
      default:
        break
    }
    this.state = TIMER_STATE.STOPED
  }

  #updateDisplay(){
    let T =this._timer

    const SM = 60 
    const MM = 60 
    const HM = 24 

    const seconds = T % SM
    T = Math.floor(T / SM) 

    const minutes = T % MM 
    T = Math.floor(T / MM) 

    const hours = T % HM 

    this.span.textContent = `${String(hours).padStart(2, '0')} : ${String(minutes).padStart(2, '0')} : ${String(seconds).padStart(2, '0')}`
  }

  get node(){
    return this._node
  }

  get dialog(){
    return this._dialog
  }

  set timer(timer:number){
    this._timer = timer
  }

  clear(){
    clearInterval(this.interval)
  }
}


export class Dialog {

  private _node:HTMLDialogElement = document.createElement("dialog")
  private form:HTMLFormElement = document.createElement("form")  
  private input:HTMLInputElement = document.createElement("input")
  private row1:HTMLDivElement = document.createElement("div")
  private row2:HTMLDivElement = document.createElement("div")

  private cancel_btn:HTMLButtonElement = document.createElement("button") 
  private confirm_btn:HTMLButtonElement  = document.createElement("button") 
  private onSubmit:(ev:SubmitEvent)=>void

  constructor(cb:(ev:SubmitEvent)=>void){
    this.onSubmit = cb
    this.#setup()
  }

  #setup(){
    this.cancel_btn.classList.add('bnt')
    this.confirm_btn.classList.add('bnt')
    this.row1.classList.add("row1")
    this.row2.classList.add("row2")

    this.#setInput(this.input,this.row1,"Timer", "number")
    this.#setSubmitButton()

    this.form.setAttribute("action","POST")

    this.form.appendChild(this.row1)
    this.form.appendChild(this.row2)
    this._node.appendChild(this.form)
  }

  #setInput(input:HTMLInputElement, insert_into: HTMLElement,name:string,type:string){
    input.classList.add(name)
    input.classList.add("in")
    let label = document.createElement("label") as HTMLLabelElement
    label.setAttribute("for",name)
    label.textContent = name
    input.setAttribute('type', type);
    input.setAttribute('name', name); 
    input.setAttribute("required","true")

    input.name = name

    let wrapper = document.createElement("div")
    wrapper.classList.add("input_wrapper")
    wrapper.appendChild(label)
    wrapper.appendChild(input)

    insert_into.appendChild(wrapper)
  }

  #setSubmitButton(){
    this.confirm_btn.classList.add("submit-btn")
    this.confirm_btn.setAttribute('type', "submit");
    this.confirm_btn.textContent = "Confirm"

    this.cancel_btn.classList.add("submit-btn")
    this.cancel_btn.setAttribute('type', "button");
    this.cancel_btn.textContent = "Cancel"

    this.cancel_btn.addEventListener('click',this.close.bind(this))
    this.form.addEventListener('submit',this.onSubmit)

    this.row2.appendChild(this.cancel_btn)
    this.row2.appendChild(this.confirm_btn)
  }

  show(){
    this._node.showModal()
  }

  close(){
    this._node.close()
  }

  get node(){
    return this._node
  }
}


export default Timer
