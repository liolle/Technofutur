
import { splitProps, type Component, type JSX, onMount, Switch, createSignal, Match } from 'solid-js';
import { showToast } from '../Toast/Toast';

type BOOKING_STATE = "pending" | "idle"

const [BookingState,setBookingState] = createSignal<BOOKING_STATE>("idle")

const BookingForm: Component = () => {
  let ref:HTMLFormElement|null

  function onSubmit(ev:SubmitEvent){
    ev.preventDefault()
    if (!ref) {return}
    let data = new FormData(ref)
    let input:BookingInputType = {
      LastName: data.get("Firstname") as string ||'',
      Firstname: data.get("Firstname") as string||'',
      Email: data.get("Firstname") as string||'',
      date: data.get("Firstname") as string||'',
      nb_of_people: parseInt(data.get("Firstname") as string )||0,
    }

    const booking = new Booking(input)
    setBookingState("pending")
    setTimeout(()=>{
      ref.reset()
      setBookingState("idle")
      showToast("Booking successfull")
    },5000)
  }

  return (
    <form onSubmit={onSubmit} action="POST" class="font-mone border-[1px] rounded border-[green] px-4 py-8 flex flex-col gap-[2rem]" ref={ref}>
      <div class="flex gap-4">
        <Input minlength={3} maxlength={30} required  name="Firstname" placeholder="Doe" type="text" />
        <Input minlength={3} maxlength={30} name="LastName" placeholder="John" type="text"/>
      </div>
      <div class="flex flex-row gap-4 w-full">
        <Input required cls="flex-[3_1_0%]" name="Email" placeholder="johndoe@test.com" type="email"/>
        <Input required cls="flex-[2_1_0%]"  name="Date" type="date"/>
      </div>

      <div class="flex justify-between items-end flex-row gap-4 w-full">
        <Input required  cls="flex-none w-32 "  name="Number of peoples" type="number"/>
        <Switch fallback={
          <button class="flex-none w-40 h-8 bg-neutral-200 flex justify-center items-center "  type="submit">
            Booking
          </button>
        }>
          <Match when={BookingState()=="pending"}>
          <button disabled class="flex-none w-40 h-8 bg-neutral-200 flex justify-center items-center "  type="submit">
            Loading...
          </button>
          </Match>
        </Switch>
      </div>

    </form>
  );
};

interface InputPropsType extends JSX.InputHTMLAttributes<HTMLInputElement> {
  cls?:string
}

const Input : Component<InputPropsType> = (props:InputPropsType)=>{
  let ref: HTMLInputElement|null
  let label_ref:HTMLLabelElement

  onMount(()=>{
    if(!ref || !ref) {return}
    label_ref.setAttribute("for",props.name)
    label_ref.textContent =props.name
  })

  const [_, rest] = splitProps(props, ["ref"]);

  return (
    <div class={`${props.cls || "" } flex flex-col gap-[.25rem] `}>
      <label class="text-neutral-200 text-sm font-bold" ref={label_ref}/>
      <input class="bg-neutral-200" ref={(el) => {
        ref = el;
      }}
        {...rest}/>
    </div>
  )
}

interface BookingInputType {
  LastName:string
  Firstname:string
  Email:string
  date:string
  nb_of_people:number
}

class Booking {
  private _LastName:string
  private _Firstname:string
  private _Email:string
  private _date:Date
  private _nb_of_people: number

  constructor(input:BookingInputType){
    this._LastName = input.LastName
    this._Firstname = input.Firstname
    this._Email = input.Email
    this._date = new Date(input.date)
    this._nb_of_people = input.nb_of_people
  }

  get LastName(){
    return this._LastName
  }

}
export default BookingForm
