
if(localStorage.getItem("basket")===null){
    localStorage.setItem("basket", JSON.stringify([]));
}

const getBasket = ()=>{
    return JSON.parse(localStorage.getItem("basket"));
}

const setBasket = arr =>{
    localStorage.setItem("basket", JSON.stringify(arr));
}