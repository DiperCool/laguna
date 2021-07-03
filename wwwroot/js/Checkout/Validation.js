const addressInfrormationValidationAndSave = ()=>{
    let checkout = getCheckout();
    if(checkout.addressInfrormation.typeDelivery!=="Delivery") return true

    let deliveryAddress = document.querySelector("#address").value;
    let instructions = document.querySelector("#instructions").value;


    checkout.addressInfrormation.deliveryAddress= deliveryAddress;
    checkout.addressInfrormation.instructions= instructions;
    console.log(checkout.addressInfrormation);
    setCheckout(checkout);
    return true;
}


const contactsValidationAndSave=()=>{
    let name = document.querySelector("#name");
    let phone = document.querySelector("#phone");
    if(phone.value===""){
        phone.classList.add("error");
        return false;
    }
    phone.classList.remove("error");
    let checkout = getCheckout();
    checkout.contact.name= name.value;
    checkout.contact.phone = phone.value;
    setCheckout(checkout);
    return true;
}