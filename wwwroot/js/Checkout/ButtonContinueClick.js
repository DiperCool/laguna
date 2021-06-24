let buttons = document.querySelectorAll(".button-continue");

buttons.forEach(item=>{
    item.addEventListener("click",(e)=>{
        console.log('xuy');
        if(!state.levels[state.current].validation()) return;
        state.levels[state.current].isEnd=true;
        state.current=state.current+1;
        
        drawState();
    })
})