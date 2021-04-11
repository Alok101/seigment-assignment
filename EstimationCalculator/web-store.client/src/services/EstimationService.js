import { Api } from "../common/api";
import {getToken} from '../common/token';
export const EstimationCalculator = async (item,actionType) => {
  try {
      const token=getToken();
    const {data}=  await Api.post(`/estimation/print?actionType=${actionType}`,item,{
        headers: {
          'Authorization': `bearer ${token}`
        },
      });
      alert(`${data===true?'Save Data Successfully!':'Something went wrong!'}`)
  } catch (ex) {
    if(ex.response.status===401){
       window.location='/sign-up';
       alert('Unauthorized');
    }
    else{
        alert(ex.response.data.Message);
    }
  }
};