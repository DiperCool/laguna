
if(localStorage.getItem("basket")===null){
    localStorage.setItem("basket", JSON.stringify([]));
}

if(localStorage.getItem("checkout")===null){


    let obj= {
        addressInfrormation: {
            typeDelivery: "Delivery",
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

if(localStorage.getItem("promocode")===null){
    let obj = {
        code: "",
        discount: 0,
        isAvailable: false
    }
    localStorage.setItem("promocode", JSON.stringify(obj));
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

const getPromocode=()=>{
    return JSON.parse(localStorage.getItem("promocode"));
}

const setPromocode = obj =>{
    localStorage.setItem("promocode", JSON.stringify(obj));
}


const clearBasket=()=>{


    localStorage.setItem("basket", JSON.stringify([]));



    let checkout= {
        addressInfrormation: {
            typeDelivery: "Delivery",
            deliveryAddress : "",
            instructions: ""
        },
        contact:{
            name:"",
            phone: ""
        }
    }

    localStorage.setItem("checkout", JSON.stringify(checkout));


    let promocode = {
        code: "",
        discount: 0,
        isAvailable: false
    }
    localStorage.setItem("promocode", JSON.stringify(promocode));
}