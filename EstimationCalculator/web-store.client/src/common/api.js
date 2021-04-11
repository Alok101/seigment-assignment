import axios from 'axios';
import { process } from './domainUrl';

export const Api=axios.create({
baseURL:process.env.API_DOMAIN_URL
});