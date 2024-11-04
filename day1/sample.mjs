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
const stored_count = parseInt(window.localStorage.getItem("counter"))
const stored_max_count = parseInt(window.localStorage.getItem("max_counter"))
let count = isNaN(stored_count)?0: stored_count
let max_count = isNaN(stored_max_count)?0: stored_max_count

const leftPart = document.createElement("div")
leftPart.innerHTML = `
<div id="max_counter" style="position: absolute;top: 50px; right: 50px; border-radius: 100%; padding: 10px; border: 2px dashed green; font-size: 50px;">${max_count}</div>
<div id="counter">${count}</div>
<div style="display: flex; justify-content: center; align-content: center; gap: 10px">
    <button id="increment_button"> Increment </button>
    <button id="reset_button"> Reset </button>
</div>
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
const counter = document.querySelector("#counter")
const max_counter = document.querySelector("#max_counter")

const updateCounter = (val) => {
    count++
    const new_max = Math.max(max_count,count)
    counter.innerText = count
    if (count>max_count){
        max_count = new_max
        max_counter.innerText = max_count
        window.localStorage.setItem("max_counter", max_count)
    }

    window.localStorage.setItem("counter", count)
}

const resetCounter = ()=>{
    count = 0
    window.localStorage.setItem("counter", count)
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

const reset_button = document.querySelector("#reset_button")
reset_button.addEventListener("click", resetCounter)

const interval = setInterval(()=>{
    if(Math.random()<0.05){
        resetCounter()
    }else {
        updateCounter()
    }
},1000)




