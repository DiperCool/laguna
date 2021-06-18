var func2 = async ()=>{
    let categories = (await axios.get("/category/GetCategories")).data;
    draw("#select", categories);
}
func2();

let draw = (idSelect,categories)=>{
    let select = document.querySelector(idSelect);
    for(let i = 0; i< categories.length; i++)
    {
        let option = new Option(categories[i].name, categories[i].id);
        select.add(option, undefined);
    }
}