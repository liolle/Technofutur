const lion_enclo = document.querySelector("#lion_enclo .animal-container");

const giraffe_enclo = document.querySelector("#giraffe_enclo .animal-container");


let selected_animal = null

const giraffes = []
const lions = []

const giraffe = ()=> {
    const el = document.createElement("div")
    el.textContent = "🦒"
    el.addEventListener("click", () => {
        if (selected_animal ) {
            selected_animal.classList.remove("active")
        }
        el.classList.add("active")
        selected_animal = el
    })
    return el
}
const lion = ()=> {
    const el = document.createElement("div")
    el.textContent = "🦁"
    el.addEventListener("click", () => {
        if (selected_animal ) {
            selected_animal.classList.remove("active")
        }
        el.classList.add("active")
        selected_animal = el
    })
    return el
}

giraffes.push(giraffe())
lions.push(lion())




for (const li of lions) {
    lion_enclo.appendChild(li)
}

for (const gi of giraffes) {
    giraffe_enclo.appendChild(gi)
}

// buttons
const add_before_btn = document.querySelector("#add-before")
const add_after_btn = document.querySelector("#add-after")



add_before_btn.addEventListener("click", () => {
    if (!selected_animal) {
        return
    }
    switch (selected_animal.textContent) {
        case "🦁":
            selected_animal.before(lion())
            break
        case "🦒":
            selected_animal.before(giraffe())
            break
        default:
            break
    }
})

add_after_btn.addEventListener("click", () => {
    if (!selected_animal) {
        return
    }
    switch (selected_animal.textContent) {
        case "🦁":
            selected_animal.after(lion())
            break
        case "🦒":
            selected_animal.after(giraffe())
            break
        default:
            break
    }
})



