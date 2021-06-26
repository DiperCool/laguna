let promocodeButton = document.querySelector("#usePromocode");
let promocodeInput = document.querySelector("#promocode");
let promocode = getPromocode();
promocodeButton.addEventListener("click",async ()=>{
    let promocodeInputVal = promocodeInput.value;
    if(!promocodeInputVal) return;
    let data = await axios.get(`promocode/getpromocodebycode?code=${promocodeInputVal}`);
    data = data.data;
    if(!data.isAvailable){
        setCheckout({
            code: "",
            discount: 0,
            isAvailable: false
        });
        alert("Промокод недоступный")
    }
    else{
        setPromocode(data);
    }
    draw();
    

});

if(promocode.code && promocode.isAvailable){
    promocodeInput.value= promocode.code;
}
