
if(getPromocode().code!==""){
    let promocode = getPromocode();
    let loadPromocode = async()=>{
        let data = (await axios.get(`promocode/getPromocodeByCode?code=${promocode.code}`)).data;
        console.log(data);
        if(!data.isAvailable){
            setPromocode({
                code: "",
                discount: 0,
                isAvailable: false
            });
        }
        else{
            setPromocode(data);
        }
    }
    loadPromocode();
}