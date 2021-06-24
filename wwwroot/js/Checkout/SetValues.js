let setValues = ()=>{
    let checkout = getCheckout();

    document.querySelector("#address").value = checkout.addressInfrormation.deliveryAddress;
    document.querySelector("#instructions").value = checkout.addressInfrormation.instructions;
    let divInstrucations = document.querySelector("#instruction-delivery");
    if(checkout.addressInfrormation.instructions){
        divInstrucations.classList.remove("hide");
    }

    let deliveryButton= document.querySelector("#delivery-button");
    let pickupButton = document.querySelector("#pickup-button");
    let deliveryInfo = document.querySelector(".delivery-information");
    let pickupInfo = document.querySelector(".pickup-information")

    if(checkout.addressInfrormation.typeDelivery==="Delivery"){
        deliveryButton.classList.add("button-actived");
        pickupInfo.classList.add("hide");
        deliveryInfo.classList.remove("hide");
    }
    else{
        pickupButton.classList.add("button-actived");
        deliveryInfo.classList.add("hide");
        pickupInfo.classList.remove("hide");
    }


    let name = document.querySelector("#name");
    name.value= checkout.contact.name;

    let phone = document.querySelector("#phone");
    phone.value= checkout.contact.phone;
}

setValues();