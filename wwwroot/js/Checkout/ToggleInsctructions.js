let link = document.querySelector(".linkInstructions");
let instDel= document.querySelector("#instruction-delivery");
link.addEventListener("click", ()=>{
    instDel.classList.toggle("hide");
})