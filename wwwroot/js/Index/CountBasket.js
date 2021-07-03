let items = getBasket();

let updateBasket=async()=>{
    let result = await axios.get("/basket/getProducts");
    let itemsToSave=[];
    
    result.data.forEach((item,i) => {
        let index = items.findIndex(x=>x.prod.id===item.id);
        if(index===-1) return;
        items[index].prod=item;
        items[index].costAll= item.cost* items[index].amount;
        itemsToSave.push(items[index]);
    });
    setBasket(itemsToSave);
    console.log(itemsToSave);

}
updateBasket();
let countBasket=()=>{
    let span = document.querySelector("#count");
    let spanMobile = document.querySelector(".cost-mobile");
    let redCircle = document.querySelector(".red-circle");
    if( items.length === 0)
    {
        span.innerHTML="0 грн";
        spanMobile.innerHTML="0";
        redCircle.innerHTML="";
        return 0;
    }
    let count = items.reduce((sum,current)=>{
        return sum+current.costAll;
    },0);
    span.innerHTML=count + " грн"
    spanMobile.innerHTML= count;
    redCircle.innerHTML=items.length;
    return count;
}


let addProduct = async(id)=>{
    let index =items.findIndex(x=>x.prod.id===id);
    if(index!==-1)
    {
        let item = items[index];
        items[index].amount+=1;
        items[index].costAll=item.amount * item.prod.cost;
    }
    else{
        let res = (await axios.get(`/basket/GetCostsProduct?id=${id}`)).data;
        items.push({
            prod: res,
            costAll: res.cost,
            amount: 1
        })
    }
    setBasket(items);
    countBasket();
}

let deleteProductsAmount=(id)=>{
    let index =items.findIndex(x=>x.prod.id===id);
    if(index===-1) return;
    let item = items[index];
    if(item.amount<=1)
    {
        items=items.filter(item=>item.prod.id!==id);
        console.log("lol");
    }
    else{
        item.costAll-=item.prod.cost;
        item.amount-=1;
        items[index]=item;
    }
    setBasket(items);
    countBasket();
}

let deleteProduct=(id)=>{
    items=items.filter(item=>item.prod.id!==id);
    setBasket(items);
    countBasket();
}