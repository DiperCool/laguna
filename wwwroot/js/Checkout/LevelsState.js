let adressInformationLevel = {
    number : 0,
    class: "address-information",
    validation : addressInfrormationValidationAndSave,
    setHeadContent: setAddressHeadsContent,
    isEnd: false,
}

let contactsLevel = {
    number : 1,
    class: "contacts",
    validation : contactsValidationAndSave,
    setHeadContent: setContactsHeadsContent,
    isEnd: false,
}
let paymentsLevel ={
    number : 2,
    class: "payments",
    validation: ()=>true,
    setHeadContent: setPaymentsHeadsContent,
    isEnd: false,
}

let checkLevel ={
    number : 3,
    class: "check",
    validation: ()=>true,
    setHeadContent: ()=>[],
    isEnd: false
}

let state = {
    current: 0,
    isOrderComplete:false,
    levels:[adressInformationLevel,contactsLevel,paymentsLevel,checkLevel]
}



let drawState=()=>{
    if(state.isOrderComplete){
        let content = document.querySelector(".levels");
        content.classList.add("hide");
        let thanks= document.querySelector(".thanks");
        thanks.classList.remove("hide");
        return;
    }
    state.levels.forEach(item => {
        let level = document.querySelector("."+item.class);
        let levelHead  = level.querySelector(".preview");
        let levelBody = level.querySelector(".body");
        let span = levelHead.querySelector(".fa-check");
        let changeButton = levelHead.querySelector(".change-button");
        let contentPreview = levelHead.querySelector(".content-preview");
        if(item.number===state.current){
            levelBody.classList.remove("hide");
            span.setAttribute("hidden", "true");
            changeButton.classList.add("hide");
            contentPreview.innerHTML="";
            
            let confirm = document.querySelector("#confirm-order")
            if(state.current===3){
                confirm.classList.remove("hide");
            }
            else{
                confirm.classList.add("hide");
            }
        }
        else if (item.isEnd) {
            span.removeAttribute("hidden");
            levelBody.classList.add("hide");
            changeButton.classList.remove("hide");
            if(contentPreview.innerHTML!=="") return;
            item.setHeadContent().forEach((content)=>{
                if(!content) return;
                let i = document.createElement("i");
                i.textContent=content;
                let br= document.createElement("br");
                contentPreview.appendChild(i);
                contentPreview.appendChild(br);
            });

        }
        else{
        
            contentPreview.innerHTML="";
            levelBody.classList.add("hide");
        }
    });
}

drawState();