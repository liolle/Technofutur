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

// console.log(persone.firstName + ' ' + persone.lastName)
// console.log(persone.fullName())

setTimeout(()=>{
    const body =document.querySelector("body")
    const fullNameDiv = document.createElement("div")
    fullNameDiv.classList.add("fullName")

    fullNameDiv.innerText = persone.fullName()
    body.appendChild(fullNameDiv)
},1)
