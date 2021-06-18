let func = async ()=>{
    let categories = (await axios.get("/Category/GetCategories")).data;
    let nav= document.querySelector("#nav");
    for(let i = 0; i<categories.length; i++)
    {
        var link = document.createElement("a");
        link.text=categories[i].name;
        link.setAttribute("href","#");
        link.classList.add("redButton");
        nav.appendChild(link);
    }

    let selects = document.querySelectorAll(".select-category");
    for(let i= 0 ;i<selects.length; i++){
        let select = selects[i];
        for(let i = 0; i< categories.length; i++)
        {
            let option = new Option(categories[i].name, categories[i].id);
            select.add(option, undefined);
        }
    }
}