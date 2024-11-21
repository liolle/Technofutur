import "@/pages/404/index.css";
import html from "@/pages/404/index.html" 
function handle() {
  const app = document.querySelector("#app") as HTMLDivElement
  const container = document.createElement("div") as HTMLDivElement
  container.classList.add("page")
  container.innerHTML = html
  app.appendChild(container)
}


export const handle404 = {
  handle: handle,
  cleanUp: ()=>{}
}
