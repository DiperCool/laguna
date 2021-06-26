let confirmButton = document.querySelector("#confirm-order");


confirmButton.addEventListener("click", async()=>{
    let checkout = getCheckout();
    let basket= getBasket();
    let addressInfo = checkout.addressInfrormation;
    let contacts = checkout.contact;


    let products=[];
    basket.forEach(item => {
        products.push({ IdProduct: item.prod.id, Amount: item.amount });
    });
    let promocode = getPromocode();
    await axios.post("/checkout/SendCheckout", 
        {
            Name: contacts.name,
            Phone : contacts.phone,
            DeliverPlace: addressInfo.deliveryAddress,
            Delivery: addressInfo.typeDelivery,
            Instructions: addressInfo.instructions,
            Products: products,
            PromocodesCode: promocode.code,
        }
    );
});