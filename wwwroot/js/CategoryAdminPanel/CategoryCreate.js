var buttonCreate = document.querySelector("#add-button");
let select = document.querySelector("#add-select");
buttonCreate.addEventListener("click", async ()=>{
    let formData = new FormData();
    
    let name= document.getElementById("add-name").value;
    let file = document.getElementById("add-file");
    formData.append("Name", name);
    formData.append("File", file.files[0]);
    await axios.post("/Category/CreateCategories", formData,{
        headers:{
            'Content-Type': 'multipart/form-data'
        }
    });
    location.reload();

});