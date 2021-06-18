
var button= document.querySelector("#change-button");
button.addEventListener("click", async()=>{
    let select = document.querySelector("#change-select");
    let name= document.querySelector("#change-name")
    await axios.post("/category/ChangeCategoriesName", { id: select.value, Name: name.value })
    location.reload();
});