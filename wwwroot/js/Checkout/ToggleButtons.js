let deliveryButton= document.querySelector("#delivery-button");
let pickupButton = document.querySelector("#pickup-button");
let deliveryInfo = document.querySelector(".delivery-information");
let pickupInfo = document.querySelector(".pickup-information")
deliveryButton.addEventListener("click", ()=>{
    if(!pickupInfo.classList.contains("hide")){
        pickupInfo.classList.add("hide");
        toggleButtons();
    }
    deliveryInfo.classList.remove("hide");
    let checkout  = getCheckout();
    checkout.addressInfrormation.typeDelivery="Delivery";
    setCheckout(checkout);
   
    
});
pickupButton.addEventListener("click", ()=>{
    if(!deliveryInfo.classList.contains("hide")){
        deliveryInfo.classList.add("hide");
        toggleButtons();
    }
    pickupInfo.classList.remove("hide");
    let checkout  = getCheckout();
    checkout.addressInfrormation.typeDelivery="Pickup";
    setCheckout(checkout);
})


const toggleButtons=()=>{
    deliveryButton.classList.toggle("button-actived");
    pickupButton.classList.toggle("button-actived");
}