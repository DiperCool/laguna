
let promocode = getPromocode();
if(promocode.code && promocode.isAvailable){
    
    let payToProm = document.querySelectorAll(".to-pay-promo");
    let payTos= document.querySelectorAll(".to-pay");
    payToProm.forEach(item=> {
        item.classList.remove("hide");
        let count= countBasket();
        let span = item.querySelector(".to-pay-promo-span");
        span.innerHTML = count-Math.round(countBasket()/100 * getPromocode().discount);
    });

    payTos.forEach(item=>{
        item.classList.add("pay-to-line-through")
    })
}