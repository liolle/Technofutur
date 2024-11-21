import "@/pages/edit/index.css";
import html from "@/pages/edit/index.html" 
const body = document.querySelector("body") as HTMLBodyElement

function handle() {
  const app = document.querySelector("#app") as HTMLDivElement
  const container = document.createElement("div") as HTMLDivElement
  container.classList.add("page")
  container.innerHTML = html
  app.appendChild(container)
}
export const editHandle = {
  handle: handle,
  cleanUp: ()=>{}
}
