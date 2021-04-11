import {Redirect} from 'react-router-dom'
export const AuthUser=props=>{
    debugger;
    const{msgType}=props;
    if(msgType==='UnAuthorized') return <Redirect to="/sign-up"/>;
    else if(msgType==='success') return <Redirect to="/estimation/screen"/>;
}