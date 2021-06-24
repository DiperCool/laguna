
if(localStorage.getItem("basket")===null){
    localStorage.setItem("basket", JSON.stringify([]));
}

if(localStorage.getItem("checkout")===null){


    let obj= {
        addressInfrormation: {
            typeDelivery: "Доставка",
            deliveryAddress : "",
            instructions: ""
        },
        contact:{
            name:"",
            phone: ""
        }
    }

    localStorage.setItem("checkout", JSON.stringify(obj));

}

const getBasket = ()=>{
    return JSON.parse(localStorage.getItem("basket"));
}

const setBasket = arr =>{
    localStorage.setItem("basket", JSON.stringify(arr));
}

const getCheckout = ()=>{
    return JSON.parse(localStorage.getItem("checkout"));
}
const setCheckout = obj =>{
    localStorage.setItem("checkout", JSON.stringify(obj));
}
