let productsDiv = document.querySelector("#products");
let products = getBasket();

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
    costDiv.innerHTML=countBasket();
});