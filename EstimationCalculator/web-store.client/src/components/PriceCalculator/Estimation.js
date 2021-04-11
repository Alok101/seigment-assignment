import React,{ useState } from "react";
import { getCustomerDetails } from "../../common/token.js";
import {PrinttoFile,PrinttoPaper} from './EstimationAction'
import {Nav,Button} from 'react-bootstrap';
import './Estimation.css';

  const Estimation = () => {
  const customerDetails = getCustomerDetails();
  const discountItem=customerDetails.discountRule;
  const apiModel={
    customerId:'',
    customerType:'',
    discountPercentage:'',
    totalAmountAfterDiscount:'',
    itemDetails:{
        price: '',
        weight: '',
        totalPrice: ''
    }
  };

  const [estimattedItem, setEstimattedItem] = useState(apiModel);
  const handlePriceInput = (event) => {
    setEstimattedItem((prev) => ({
        itemDetails:{
            ...prev.itemDetails,
            price: event.target.value,
            totalPrice:calculateTotalPrice(event.target.value,estimattedItem.itemDetails.weight)
        }
    }));
  };

  const handleWeightInput = (event) => {
  setEstimattedItem((prev) => ({
    itemDetails:{
        ...prev.itemDetails,
        weight: event.target.value,
        totalPrice:calculateTotalPrice(event.target.value,estimattedItem.itemDetails.price)
    }
}));
};

  const handleOperation = async(actionType) => {
   const permissionToGetDiscount= customerDetails.discountRule.applicable;
    const totalAmountAfterDiscount=permissionToGetDiscount?calculateDiscountPrice():estimattedItem.itemDetails.totalPrice;
    estimattedItem.customerId=customerDetails?.id;
    estimattedItem.customerType=customerDetails?.type;
    estimattedItem.discountPercentage=customerDetails.discountRule.pricePercentage;
    estimattedItem.totalAmountAfterDiscount=totalAmountAfterDiscount;
    if(estimattedItem.itemDetails.price ==='' || estimattedItem.itemDetails.weight ==='' || estimattedItem.itemDetails.totalPrice ===''){
        alert('fill required field');
        return;
    }
    switch(actionType){
        case 'printtoscreen':
            alert(`User Type : ${estimattedItem.customerType}\r\nGold Price (per gram) : ${estimattedItem.itemDetails.price}\r\nWeight (gram) : ${estimattedItem.itemDetails.weight}\r\nTotal Price : ${estimattedItem.itemDetails.totalPrice}\r\nDiscount (%) : ${estimattedItem.discountPercentage}\r\nTotal Amount : ${estimattedItem.totalAmountAfterDiscount===undefined?'':estimattedItem.totalAmountAfterDiscount}`);
            break;
            case 'printtofile':
                await PrinttoFile(estimattedItem);
                break;
                case 'printtopaper':
                    await PrinttoPaper(estimattedItem);
                    break;
                        default:
                            break;
    }
  };
 
  const calculateDiscountPrice=()=>{
    const item=estimattedItem.itemDetails;
      let totalPrice=calculateTotalPrice(item.price,item.weight);
      let discountPrice=totalPrice-((totalPrice*discountItem.pricePercentage)/100);
      return  discountPrice; 
  }

  const calculateTotalPrice=(price,weight)=>{
    const totalprice= parseFloat((price * weight).toFixed(2));
    return totalprice;
  }
  const handleClear=()=>{
      setEstimattedItem(apiModel);
  }
const handleSubmit=(event)=>{
    event.preventDefault();
    setEstimattedItem((prev) => ({
        ...prev,
        totalAmountAfterDiscount:calculateDiscountPrice()
    }));
}
  return (
<>
<Nav className="navbar navbar-inverse">
  <div className="container-fluid bg-dark">
    <div className="navbar-header">
      <a className="navbar-brand" href="/">Estimation Screen</a>
    </div>
    <ul className="nav navbar-nav navbar-right">
    <li><span style={{color:"white"}}> Welcome {customerDetails.type} User</span></li>
    </ul>
  </div>
</Nav>
<div className="container">
 <form onSubmit={handleSubmit} className="form-horizontal">
 <div className="form-group required">
      <label className="control-label col-sm-2">Gold Price (per gram)</label>
        <input
        className="form-control col-sm-10"
          type="number"
          value={estimattedItem.itemDetails.price}
          onChange={handlePriceInput}
          placeholder="Enter Price"
          name="price"
          required
        />
    
     </div>
     <div className="form-group required">
     <label className="control-label col-sm-2">Weight (grams)</label>
        <input
        className="form-control col-sm-10"
          type="number"
          value={estimattedItem.itemDetails.weight}
          onChange={handleWeightInput}
          placeholder="Enter Weight"
          name="weight"
          required
        />
      </div>
      <div className="form-group">
      <label className="control-label col-sm-2">
        Total Price
        </label>
        <input
        className="form-control col-sm-10"
          readOnly={true}
          value={estimattedItem.itemDetails.totalPrice}
          type="number"
          name="totalPrice"
        />
      </div>
      {customerDetails && customerDetails.discountRule.itemVisible ? (
            <div className="form-group">
         <label className="control-label col-sm-2">
          Discount %
          </label>
          <input
          className="form-control col-sm-10"
            type="number"
            name="pricePercentage"
            readOnly={customerDetails.discountRule.applicable}
            value={customerDetails.discountRule.pricePercentage}
          />
        </div>
      ) : null}
      <div className="form-group">
      <label className="control-label col-sm-2">
        Total Amount
        </label>
        <input
          className="form-control col-sm-10"
            type="number"
            name="totalAmount"
            value={estimattedItem.totalAmountAfterDiscount}
            readOnly={true}
          />
      </div>
     <div className="row">
         <div className="col-sm-2">
         <Button type="submit"  className="btn btn-primary">
          Calculate
        </Button>
         </div>
         <div className="col-sm-2">
         <Button type="button"  className="btn btn-primary" onClick={() => handleOperation("printtoscreen")}>
          Print to Screen
        </Button>
         </div>
        <div className="col-sm-2">
        <Button type="button" className="btn btn-primary" onClick={() => handleOperation("printtofile")}>
          Print to File
        </Button>  
             </div>
        <div className="col-sm-2">
        <Button type="button" className="btn btn-primary" onClick={() => handleOperation("printtopaper")}>
          Print to Paper
        </Button>
             </div>
        <div className="col-sm-2">
        <Button type="button" className="btn btn-info" onClick={handleClear}>Clear</Button>
             </div>
      </div>
      </form>
      </div>
      </>
  );
};
export default Estimation;
