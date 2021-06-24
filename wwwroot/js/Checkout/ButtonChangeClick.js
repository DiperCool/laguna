let buttonsChange = document.querySelectorAll(".change-button");
buttonsChange.forEach(item=>{
    item.addEventListener("click", (e)=>{
        if(!state.levels[state.current].validation()) return;
        let number = parseInt(item.getAttribute("data-id"));
        if(state.current!==3) state.levels[state.current].isEnd=true;
        state.levels[number].isEnd=false;
        state.current= number;
        drawState();
    })
})