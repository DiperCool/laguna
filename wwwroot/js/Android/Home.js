let products = document.querySelectorAll(".product");
let loadProducts=()=>{
    let basket = getBasket();
    products.forEach(product => {
        let id = Number.parseInt(product.getAttribute("data-id"));
        let amount= document.querySelector(`.amount[data-id="${id}"]`)
        let index = basket.findIndex(x=>x.prod.id===id);
        if(index!==-1){
            let item = basket[index];
            amount.innerHTML=item.amount;
        }
        else{
            amount.innerHTML=0;
        }
    });
}
loadProducts();


let setOnClick= ()=>{
    let pluses = document.querySelectorAll(".button-product");
    pluses.forEach(el=>{
        el.addEventListener("click",async(e)=>{
            e.stopPropagation();
            let currentTarget = e.currentTarget;
            if(currentTarget.getAttribute("disabled")){
                console.log("oleg oelg oegl");
                return;
            }
            currentTarget.setAttribute("disabled","true");
            let id = Number.parseInt(el.getAttribute("data-id"));
            let classActive= el.classList.contains("plus") ? "button-product-plus-active": "button-product-minus-active"
            el.classList.add(classActive);
            setTimeout(()=>{
                el.classList.remove(classActive);
            },1000)
            if(el.classList.contains("plus")){
                await addProduct(id);
            }
            else if(el.classList.contains("minus")){
                deleteProductsAmount(id);
            }

            loadProducts();
            currentTarget.removeAttribute("disabled");
        });
    });


}

setOnClick();