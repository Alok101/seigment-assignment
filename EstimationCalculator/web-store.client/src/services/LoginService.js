import { Api } from "../common/api";
export const ValidateUser = async (loginmodel) => {
  try {
      debugger;
      const{data}=await Api.post('/account/login',loginmodel);
      return data;
  } catch (ex) {
   if(ex.response.status===401){
    alert('Unauthorized');
 }
  }
};

