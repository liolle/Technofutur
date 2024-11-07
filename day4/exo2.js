const app = document.getElementById("app");


const picture = document.createElement("img",{
    border: "1px solid black",
    height: "200px",
    objectFit: "contain",

});
picture.setAttribute("src", "https://media.giphy.com/media/FP7g0JkFYO4gK9o4vr/giphy.gif?cid=790b7611kskffcobiq6f03xqxohg4h5y8katwq9w4idrn85s&ep=v1_gifs_trending&rid=giphy.gif&ct=g")
picture.setAttribute("id","picture");
app.appendChild(picture)
let rotation = 0

setInterval(()=>{
    rotation += 10
    picture.style.transform = `rotate(${rotation}deg)`;
},100)


