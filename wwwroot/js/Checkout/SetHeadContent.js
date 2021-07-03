
let setAddressHeadsContent = ()=>{
    let checkout = getCheckout();
    let addressInfo = checkout.addressInfrormation;
    if(addressInfo.typeDelivery==="Delivery"){
        return [ "Доставка", addressInfo.deliveryAddress, addressInfo.instructions]
    }
    return [ "Самовывоз" ];
}

let setContactsHeadsContent = ()=>{
    let checkout = getCheckout();
    let contact = checkout.contact;
    return [ contact.name, contact.phone ];
}

let setPaymentsHeadsContent =()=>{
    return [ "Оплата готівкою кур'єру" ];
}