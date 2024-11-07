const firstname = ["Alice",
    "Benjamin",
    "Chloe",
    "Daniel",
    "Emma",
    "Finn",
    "Grace",
    "Henry",
    "Isla",
    "Jack",
    "Kate",
    "Liam",
    "Mia",
    "Noah",
    "Olivia",
    "Paul",
    "Quinn",
    "Ruby",
    "Sam",
    "Zoe"]

const lastname = [
    "Adams",
    "Baker",
    "Carter",
    "Dawson",
    "Edwards",
    "Fisher",
    "Green",
    "Hill",
    "Irving",
    "Jenkins",
    "King",
    "Lewis",
    "Martin",
    "Newton",
    "O'Connor",
    "Price",
    "Robinson",
    "Scott",
    "Turner",
    "White"
];


const personneGenerator = ()=> {
    return {
        firstname: firstname[Math.floor(Math.random() * firstname.length)],
        lastname: lastname[Math.floor(Math.random() * lastname.length)],
        age: Math.floor(Math.random() * 100)+18,
    }
}

const personnes = Array.from({length:30},personneGenerator)

console.table(personnes)