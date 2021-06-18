var widthWind = document.querySelector('body').offsetWidth;
if (widthWind >= 750) {
    let products= document.getElementsByClassName("product");
    let curProd= document.getElementsByClassName("current-product")[0];

    for(let i =0; i<products.length; i++)
    {
        products[i].addEventListener("click", (e)=>{
            document.getElementById("content").classList.toggle("content-visible")
            curProd.classList.toggle("current-product-visible")
            curProd.getElementsByClassName("name")[0].innerHTML= products[i].getElementsByClassName("name")[0].innerHTML;
            curProd.getElementsByClassName("cost")[0].innerHTML= products[i].getElementsByClassName("cost")[0].innerHTML;
            curProd.getElementsByClassName("excerpt")[0].innerHTML= products[i].getElementsByClassName("excerpt")[0].innerHTML;
            curProd.getElementsByClassName("description")[0].innerHTML= products[i].getElementsByClassName("description")[0].innerHTML;
            let imgCurProd= curProd.getElementsByClassName("img-current-product")[0];
            let imgProd= products[i].getElementsByClassName("product-img")[0];
            imgCurProd.setAttribute("src", imgProd.getAttribute("src") )
        })
    }

    document.getElementsByClassName("close-current-product")[0].addEventListener("click", ()=>{
        document.getElementById("content").classList.toggle("content-visible")
        curProd.classList.toggle("current-product-visible");

    })

    document.getElementsByClassName("img-current-product")[0].addEventListener("click", ()=>{
        document.getElementById("content").classList.toggle("content-visible")
        curProd.classList.toggle("current-product-visible");

    })
}