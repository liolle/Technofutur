const PI = Math.PI

let name = 'Bruno'

let persone = {
    firstName: name,
    lastName: "River",
    age : 26,
    fullName: function (){
        return this.firstName + ' ' + this.lastName
    }

}



const body =document.querySelector("body")
let count = 0

const leftPart = document.createElement("div")
leftPart.innerHTML = `
<div id="counter">${count}</div>
<button id="increment_button"> Increment </button>
<ul class="select-none main_ul" >
<li>first</li>
<ul>
<li>nested li</li>
<li>other li</li>
</ul>
<li>second</li>
<li>third</li>
</ul>
<button id="add_button"> add </button>
`
let active_element =null

body.appendChild(leftPart)
leftPart.classList.add("main_div")

const main_ul = document.querySelector(".main_ul")
const updateCounter = () => {
    const counter = document.querySelector("#counter")
    count++
    counter.innerText = count
}


// add event listener on all li
const all_li = document.querySelectorAll("li")
for (const li of all_li) {
    li.addEventListener("click", () => {
        if (active_element == null) {
            active_element= li
        }else {
            active_element.classList.remove("active")
            active_element= li
        }
        active_element.classList.add("active")
    })
}


const fruits = [
    "Banane",
    "Mûres",
    "Myrtilles",
    "Melon",
    "Cerise",
    "Pamplemousse",
    "Mangue",
    "Fraise"
]

// setup button
const button = document.querySelector("#add_button")
button.addEventListener("click", () => {
    const new_li = document.createElement("li")
    new_li.innerHTML = `${fruits[Math.floor(Math.random() * fruits.length)]}`
    main_ul.appendChild(new_li)
})

const increment_button = document.querySelector("#increment_button")
increment_button.addEventListener("click", updateCounter)

