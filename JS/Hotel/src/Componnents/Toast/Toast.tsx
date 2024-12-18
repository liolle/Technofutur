import { Component, createSignal, For, Match } from "solid-js";

interface ToastType {
  message:string
} 
const Toast: Component<ToastType> = (props:ToastType) => {

  return (
    <div  class="flex justify-center items-center font-mono text-md text-neutral-200 rounded-lg px-4 py-2 border border-green-400 shadow-lg animate-slide-in">
      <span>{props.message}</span>
    </div>
  );
};


export const [getToasts,setToasts] = createSignal<ToastType[]>([])

export function showToast(message:string){
  const toast:ToastType = {
    message:message 
  }

  setToasts((prev) => [...prev, toast]);

  setTimeout(()=>{
    setToasts((prev) => prev.filter((el) => el != toast));
  },4000)
}

const ToastWrapper: Component = () => {

  return (
    <div id="toast-wapper" class=" absolute top-[2rem] right-[2rem]">
      <For each={getToasts()}>
        {(item) => {
          return <Toast  message={item.message}/>
        }}
      </For>
    </div>
  );
};


export default ToastWrapper


