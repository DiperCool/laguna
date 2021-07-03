let content = document.querySelector("#products");

let createInputs=(item)=>{
    let div= document.createElement("div");
    div.classList.add("input-group","inline-group","row","flex-nowrap");

    let divMinus= document.createElement("div");
    divMinus.classList.add("input-group-prepend");


    let buttonMinus= document.createElement("button");
    buttonMinus.classList.add("btn" ,"btn-outline-secondary", "btn-minus")
    buttonMinus.setAttribute("data-id", item.prod.id);
    let iMinus =document.createElement("i");
    iMinus.classList.add("fa-minus","fa");
    buttonMinus.appendChild(iMinus);

    let divInput= document.createElement("div")

    let input = document.createElement("input");
    input.setAttribute("min", "1");
    input.setAttribute("name", "quantity");
    input.setAttribute("type", "number");
    input.setAttribute("value", item.amount);
    input.setAttribute("readonly", "true");
    input.setAttribute("data-id", item.prod.id);
    input.classList.add("form-control" ,"quantity")
    divInput.appendChild(input)
    divMinus.appendChild(buttonMinus);

    div.appendChild(divMinus);
    div.appendChild(divInput);

    let divPlus= document.createElement("div");
    divPlus.classList.add("input-group-prepend");


    let buttonPlus = document.createElement("button");
    buttonPlus.classList.add("btn" ,"btn-outline-secondary", "btn-plus")
    buttonPlus.setAttribute("data-id", item.prod.id);
    let iPlus =document.createElement("i");
    iPlus.classList.add("fa-plus", "fa");
    buttonPlus.appendChild(iPlus);

    divPlus.appendChild(buttonPlus);
    div.appendChild(divPlus);
    return div;

}

let drawItem = (item)=>{
    let product = document.createElement("div");
    product.classList.add("text-nowrap", "row","d-flex", "filex-column" );

    let oneRow= document.createElement("div");
    oneRow.classList.add("col-6");
    let name= document.createElement("div");
    name.innerHTML=item.prod.name;
    let del = document.createElement("span");
    del.classList.add("delete")
    del.setAttribute("data-id", item.prod.id)
    del.textContent="Удалить";
    
    oneRow.appendChild(name);
    oneRow.appendChild(del);

    let twoRow= document.createElement("div");
    twoRow.classList.add("col-6","justify-content-end","d-flex","align-items-end", "flex-column");
    let cost= document.createElement("div");
    cost.innerHTML=item.costAll + " грн";
 

    twoRow.appendChild(cost);
    twoRow.appendChild( createInputs(item) );

    product.appendChild(oneRow);
    product.appendChild(twoRow);

    let hr= document.createElement("hr");
    hr.setAttribute("size", "1")
    hr.setAttribute("color", "white");
    content.appendChild(product);
    content.appendChild(hr);


}

let draw= ()=>{
    content.innerHTML="";
    let totals=document.querySelector(".basket-total");
    let back = document.querySelector(".back-to");
    back.classList.add("hide");
    if(countBasket()===0)
    {
        totals.classList.add("basket-total-hide");

        console.log("back!!!");
        
        back.classList.remove("hide");
        console.log(back.classList);

        return;
    }
    totals.classList.remove("basket-total-hide");
    items.forEach(item => {
        drawItem(item);
    });
    let pluses = document.querySelectorAll(".btn-plus");

    pluses.forEach(item=>{
            item.addEventListener("click", async(e)=>{
                let id= parseInt( e.currentTarget.getAttribute("data-id"));
                let input = document.querySelector(`input[data-id="${id}"]`);
                input.stepUp()
                await addProduct(id);
                draw();
        })
    })
    let minuses = document.querySelectorAll(".btn-minus");
    minuses.forEach(item=>{
            item.addEventListener("click", (e)=>{
                let id= parseInt( e.currentTarget.getAttribute("data-id"));
                let input = document.querySelector(`input[data-id="${id}"]`);
                input.stepDown()
                deleteProductsAmount(id);
                draw();
        })
    })
    let deletes = document.querySelectorAll(".delete");
    deletes.forEach(item=>{
        item.addEventListener("click", (e)=>{
            if (!window.confirm("Удалить?")) return;
            let id= parseInt( e.currentTarget.getAttribute("data-id"));
            deleteProduct(id);
            draw();
    })

    let payTo = document.querySelectorAll(".to-pay-span");
    
    payTo.forEach((item)=>{
        item.innerHTML= countBasket();
    })
    let promocode = getPromocode();


    let payToProm = document.querySelectorAll(".to-pay-promo");
    let payTos= document.querySelectorAll(".to-pay");
    if(promocode.code && promocode.isAvailable){
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
    else{
        payToProm.forEach(item=> {
            item.classList.add("hide");
        });
    
        payTos.forEach(item=>{
            item.classList.remove("pay-to-line-through")
        })
    }
})

}
draw();
