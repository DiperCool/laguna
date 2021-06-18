
var button= document.querySelector("#del-button");
button.addEventListener("click", async()=>{
    let select = document.querySelector("#del-select");
    await axios.post("/category/DeleteCategory", { id: select.value })
    location.reload();
});