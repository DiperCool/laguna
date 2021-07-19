let productsDiv = document.querySelector("#products");
let products = getBasket();
let calculateBoxes= (element)=>{
    let items = getBasket();
    let boxCostToSet = 0;
    let boxAmountToSet = 0;
    let boxProduct = document.querySelector(".box-product");
    boxProduct.classList.add("hide");
    let contProduct = document.querySelector(".container-product");
    contProduct.classList.add("hide");
    let boxCost = document.querySelector(".box-cost");
    let boxAmount = document.querySelector(".box-amount");

    let contCostToSet = 0;
    let contAmountToSet = 0;
    let contCost = document.querySelector(".container-cost");
    let contAmount = document.querySelector(".container-amount");

    items.forEach((item)=>{
        let prod = item.prod;
        
        if(prod.wrapperType==="Box"){
            boxCostToSet+=15*item.amount;
            boxAmountToSet+=item.amount;

        }
        else if(prod.wrapperType==="Container"){
            contCostToSet+=15*item.amount;
            contAmountToSet+=item.amount;
        }
    })
    let hr = document.querySelector(".boxes-hr");
    hr.classList.add("hide");
    if(boxCostToSet!=0 && contCostToSet!=0 && hr !=null){
        hr.classList.remove("hide");
    }
    if(boxCostToSet!=0){
        boxProduct.classList.remove("hide");
    }
    boxCost.innerHTML= `${boxCostToSet} грн`;
    boxAmount.innerHTML= `${boxAmountToSet}x`

    if(contCostToSet!=0){
        contProduct.classList.remove("hide");
    }
    contCost.innerHTML=  `${contCostToSet} грн`;
    contAmount.innerHTML= `${contAmountToSet}x`
    return contCostToSet+ boxCostToSet;

}
products.forEach(item => {
    let div = document.createElement("div");
    div.classList.add("d-flex");
    div.classList.add("justify-content-between");
    let divName= document.createElement("div");
    divName.innerHTML= `${item.amount}x ${item.prod.name}`;
    div.appendChild(divName);

    let cost = document.createElement("div");
    cost.classList.add("cost");
    cost.innerHTML= item.prod.cost + " грн";
    div.appendChild(cost);

    let hr = document.createElement("hr");
    hr.setAttribute("color", "white");

    
    productsDiv.appendChild(div);
    productsDiv.appendChild(hr);

    let costDiv= document.querySelector(".to-pay-span");
    costDiv.innerHTML=countBasket() + calculateBoxes();
});