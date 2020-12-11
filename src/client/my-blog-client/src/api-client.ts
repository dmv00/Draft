import axios from 'axios';
import { ICreateArticleCommand } from './models/Articles/Commands';


export const API_BASE_URL = "http://localhost:5001"  //web api base url


export class ArticlesClient {
   public async create(command: ICreateArticleCommand) {
      const url = `${API_BASE_URL}/api/article`
      const response = await axios.post<number>(url, command);
      console.log(response.data);
      return response.data;
   }
}

