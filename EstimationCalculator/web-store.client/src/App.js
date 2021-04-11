import Login from "./components/Account/Login";
import Estimation from './components/PriceCalculator/Estimation';
import {getToken} from './common/token';
import {BrowserRouter as Router,Route,Switch,Redirect} from 'react-router-dom';
function App() {
    debugger;
const token=getToken();
if(!token){
    return <Login/>
}
return (
       <>
       <Router>
           <Switch>
           <Route path='/estimation/screen' exact component={Estimation} />
           <Route path='/sign-up' exact component={Login} />
           token?<Redirect to={'/estimation/screen'}/> :<Redirect to={'/sign-up'}/>;
           </Switch>
        </Router>
     </>
    );
  }
  
  export default App;