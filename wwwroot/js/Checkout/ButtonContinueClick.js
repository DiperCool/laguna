let buttons = document.querySelectorAll(".button-continue");

buttons.forEach(item=>{
    item.addEventListener("click",(e)=>{
        if(!state.levels[state.current].validation()) return;
        setTimeout(()=>{
            state.levels[state.current].isEnd=true;
            state.current=state.current+1;
            
            drawState();
        },200)
    })
})