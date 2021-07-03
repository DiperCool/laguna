var widthWind = document.querySelector('body').offsetWidth;
if (widthWind >= 750) {
    let products= document.getElementsByClassName("product");
    let curProd= document.querySelector(".current-product");
    let button = document.querySelector("#button-current-product");
    let click= async function (e){
        button.setAttribute("disabled", "true")
        let id = parseInt(button.getAttribute("data-id"));
        console.log(e)
        await addProduct(id);
        button.removeAttribute("disabled");
    }
    button.addEventListener("click",click);

    for(let i =0; i<products.length; i++)
    {
        products[i].addEventListener("click",  (e)=>{
            let id = parseInt(products[i].getAttribute("data-id"));
            button.setAttribute("data-id", id);

            document.querySelector("#content").classList.toggle("content-visible")
            curProd.classList.toggle("current-product-visible")
            curProd.querySelector(".name-current").innerHTML= products[i].querySelector(".name").innerHTML;
            curProd.querySelector(".cost-current").innerHTML= products[i].querySelector(".cost").innerHTML;
            curProd.querySelector(".excerpt-current").innerHTML= products[i].querySelector(".excerpt").innerHTML;
            curProd.querySelector(".description-current").innerHTML= products[i].querySelector(".description").innerHTML;
            let imgCurProd= curProd.querySelector(".img-current-product");
            let imgProd= products[i].querySelector(".product-img");
            
            imgCurProd.setAttribute("src", imgProd.getAttribute("src") );
            document.body.scrollTop=0;
        })
    }

    document.getElementsByClassName("close-current-product")[0].addEventListener("click", ()=>{
        
        document.querySelector("#content").classList.toggle("content-visible")
        curProd.classList.toggle("current-product-visible");

    })

    document.getElementsByClassName("img-current-product")[0].addEventListener("click", ()=>{
        document.querySelector("#content").classList.toggle("content-visible")
        curProd.classList.toggle("current-product-visible");

    })


}

let pluses = document.querySelectorAll(".button-buy");

for (let i = 0; i < pluses.length; i++) {
    pluses[i].addEventListener("click",async(e)=>{
        e.stopPropagation();
        
        let target = e.currentTarget;
        if(target.getAttribute("disabled")) return;
        let id = parseInt(target.getAttribute("data-id"));
        target.setAttribute("disabled", "true");
        let use = target.querySelector("#use");
        use.classList.remove("plus-button-active");
        use.classList.add("plus-button-active");
        console.log(target);
        setTimeout(()=>{
            use.classList.remove("plus-button-active");
        },1000)
        await addProduct(id);
        target.removeAttribute("disabled");
    })
}