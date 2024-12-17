import Car from '../../Car'
import { setCurrentCar } from '../../Store'
import './CarFrom.css'

class CarForm {

  private _node:HTMLFormElement 

  mark:HTMLInputElement = document.createElement("input")
  model:HTMLInputElement = document.createElement("input")
  year:HTMLInputElement = document.createElement("input")
  power:HTMLInputElement = document.createElement("input")
  consuption:HTMLInputElement = document.createElement("input")
  tank_capacity:HTMLInputElement = document.createElement("input")
  submit:HTMLInputElement = document.createElement("input")
  row1:HTMLDivElement = document.createElement("div")
  row2:HTMLDivElement = document.createElement("div")
  row3:HTMLDivElement = document.createElement("div")
  row4:HTMLDivElement = document.createElement("div")

  constructor(){
    this._node = document.createElement("form") 
    this.#setup()
  }
  
  #setup(){
    // set Attributes
    this.row1.classList.add("row1")
    this.row2.classList.add("row2")
    this.row3.classList.add("row3")
    this.row4.classList.add("row4")
    this.#setInput(this.mark,this.row1,"Mark","text")
    this.#setInput(this.model,this.row1,"Model", "text")
    this.#setInput(this.year,this.row2,"Year", "date")
    this.#setInput(this.power,this.row2,"Power", "number")
    this.#setInput(this.tank_capacity,this.row3,"Capacity", "number")
    this.#setInput(this.consuption,this.row3,"Consuption", "number")
    this.#setSubmitButton()
    this._node.setAttribute("action","POST")

    // Appernd elements  
    this._node.appendChild(this.row1)
    this._node.appendChild(this.row2)
    this._node.appendChild(this.row3)
    this._node.appendChild(this.row4)

    // Event listener
    this._node.addEventListener("submit",(ev)=>{
      ev.preventDefault()
      let target = ev.target as HTMLFormElement 
      if(!target){return}
      let data = new FormData(target)
      this.mark.value = this.mark.value.trim()
      this.model.value = this.model.value.trim()

      if (!this.mark.checkValidity() || !this.model.checkValidity()) {
        this.mark.reportValidity();
        this.model.reportValidity();
        return 
      }

      
      let mark = data.get("Mark") as string
      let model = data.get("Model") as string
      let year = data.get("Year") as string
      let power = data.get("Power") as string
      let capacity = data.get("Capacity")as string
      let consuption = data.get("Consuption") as string

      if(!mark && !model || !year || !power || !capacity || !consuption){
        return
      }
      setCurrentCar(new Car(mark,model,parseInt(power),new Date(year),parseInt(power),parseInt(consuption)))
    })
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

    // input specific Attributes
    /*
    switch (name) {
      case "Mark":
        break;
      case "Model":
        break;
      default:
        break;
    }
    */
    input.name = name

    let wrapper = document.createElement("div")
    wrapper.classList.add("input_wrapper")
    wrapper.appendChild(label)
    wrapper.appendChild(input)

    insert_into.appendChild(wrapper)
  }

  #setSubmitButton(){
    this.submit.classList.add("submit-btn")
    this.submit.setAttribute('type', "submit");
    this.submit.value = "Add Car"
    this.row4.appendChild(this.submit)
  }

  get node(){
    return this._node
  }
}

export default CarForm
