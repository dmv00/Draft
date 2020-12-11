import axios from 'axios';
import { ICreateArticleCommand } from './models/articles/commands';
import { Response } from './models/response-model'

export const API_BASE_URL = "http://localhost:5001"  //web api base url


export class ArticlesClient {
   public async create(command: ICreateArticleCommand) {
      const url = `${API_BASE_URL}/api/article`
      const response = await axios.post<Response<number>>(url, command);
   
      return response.data.data;
   }
}

