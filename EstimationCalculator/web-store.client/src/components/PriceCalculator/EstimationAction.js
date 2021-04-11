import {EstimationCalculator} from '../../services/EstimationService'
export const PrinttoFile=async(estimattedItem)=>{
   await EstimationCalculator(estimattedItem,'file');
}
export const PrinttoPaper=async(estimattedItem)=>{
    await EstimationCalculator(estimattedItem,'paper');
}