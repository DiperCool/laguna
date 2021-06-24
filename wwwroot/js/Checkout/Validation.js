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
    let name = document.querySelector("#name").value;
    let phone = document.querySelector("#phone").value;
    if(phone==="") return false;
    let checkout = getCheckout();
    checkout.contact.name= name;
    checkout.contact.phone = phone;
    setCheckout(checkout);
    return true;
}