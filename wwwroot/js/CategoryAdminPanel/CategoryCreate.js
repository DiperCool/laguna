var buttonCreate = document.querySelector("#add-button");
let select = document.querySelector("#add-select");
buttonCreate.addEventListener("click", async ()=>{

    let name= document.getElementById("add-name").value;
    await axios.post("/Category/CreateCategories", {Name : name});
    location.reload();

})