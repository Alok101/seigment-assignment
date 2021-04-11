export const getToken=()=>{
    const sessionData=getFromSessionStorage();
    const token= sessionData?.token;
    if(!token){
        const localStorageData=getFromLocalStorage();
        const token= localStorageData?.token;
        return token;
    }
    return token;
}
export const setCustomerDetails=(details)=>{
    setInSessionStorage(details); 
    setInLocalStorage(details);
}
export const clearToken=()=>{
    sessionStorage.removeItem('customer_details');
    localStorage.removeItem('customer_details');
}
export const getCustomerDetails=()=>{
const sessionData=getFromSessionStorage();
const customerDetails= sessionData?.customerDetails;
if(!customerDetails){
    const localStorageData=getFromLocalStorage();
    const customerDetails= localStorageData?.customerDetails;
    return customerDetails;
}
return customerDetails;
}

const setInSessionStorage=(details)=>{
    sessionStorage.setItem('customer_details',JSON.stringify(details));
}
const setInLocalStorage=(details)=>{
    localStorage.setItem('customer_details',JSON.stringify(details));
}
const getFromSessionStorage=()=>{
const detailsString=sessionStorage.getItem('customer_details');
if(detailsString==='undefined') return '';
const userDetails=JSON.parse(detailsString);
return userDetails;
}
const getFromLocalStorage=()=>{
    const detailsString=localStorage.getItem('customer_details');
    if(detailsString==='undefined') return '';
    const userDetails=JSON.parse(detailsString);
    return userDetails;
}