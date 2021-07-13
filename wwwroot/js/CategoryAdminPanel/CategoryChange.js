
var button= document.querySelector("#change-button");
button.addEventListener("click", async()=>{
    let formData = new FormData();
    
    let select = document.querySelector("#change-select");
    let name= document.querySelector("#change-name").value;
    let file = document.querySelector("#change-file");
    formData.append("Name", name);
    formData.append("File", file.files[0]);
    formData.append("Id", select.value);
    await axios.post("/category/ChangeCategory", formData,{
        headers:{
            'Content-Type': 'multipart/form-data'
        }
    });
    location.reload();
});