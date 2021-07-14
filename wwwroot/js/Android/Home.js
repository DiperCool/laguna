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
document.addEventListener("click",(e)=>{
    let classList = e.target.classList;
    if(classList.contains("img-product")) return;
    clearActiveContainer();
})
var containers = document.querySelectorAll(".container-img-product");
const  clearActiveContainer = ()=>{
    containers.forEach(el=>{
        let button = el.querySelector(".img-product-button");
        let middle = el.querySelector(".middle");
        let photo = el.querySelector(".img-product");
        button.classList.remove("img-product-button-active");
        middle.classList.remove("middle-active");
        photo.classList.remove("img-product-active");
        el.classList.remove("container-img-product-active");
    })
    console.log("clear")
}
containers.forEach(el=>{
    let photo = el.querySelector(".img-product");
    el.addEventListener("click",()=>{
        if(photo.classList.contains("img-product-active")){
            clearActiveContainer();
            return;
        }
        clearActiveContainer();
        let button = el.querySelector(".img-product-button");
        let middle = el.querySelector(".middle");
        
        button.classList.add("img-product-button-active");
        middle.classList.add("middle-active");
        photo.classList.add("img-product-active");
        el.classList.add("container-img-product-active");
    });
})

let setOnClick= ()=>{
    let pluses = document.querySelectorAll(".button-product");
    pluses.forEach(el=>{
        el.addEventListener("click",async(e)=>{
            e.stopPropagation();
            clearActiveContainer();
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

let buttonsImg=document.querySelectorAll(".img-product-button");
buttonsImg.forEach((el)=>{
    el.addEventListener("click",async (e)=>{
        e.stopPropagation();
        let currentTarget = e.currentTarget;
        if(currentTarget.getAttribute("disabled")){
            console.log("oleg oelg oegl");
            return;
        }
        currentTarget.setAttribute("disabled","true");
        let id = Number.parseInt(el.getAttribute("data-id"));
        await addProduct(id);
        loadProducts();
        currentTarget.removeAttribute("disabled");
        clearActiveContainer();

    })
})
