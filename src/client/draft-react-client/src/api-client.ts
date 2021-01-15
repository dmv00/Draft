import axios from 'axios';
import { ICreateArticleCommand, IUpdateArticleCommand } from './models/article/commands';
import { ArticleByIdDto, ArticlesDto } from './models/article/dtos';
import { IGetArticleByIdQuery } from './models/article/queries';
import { Response } from './models/response-model'

export const API_BASE_URL = "http://localhost:5000"  //web api base url


export class ArticlesClient {
   private _url = `${API_BASE_URL}/api/article`;

   public async create(command: ICreateArticleCommand): Promise<Response<number>> {
      const response = await axios.post<Response<number>>(this._url, command);
      return response.data;
   }

   public async update(command: IUpdateArticleCommand): Promise<Response<number>> {
      const response = await axios.put<Response<number>>(this._url, command);
      return response.data;
   }

   public async delete(): Promise<Response<number>> {
      const response = await axios.delete<Response<number>>(this._url);
      return response.data;
   }
   public async getById(query: IGetArticleByIdQuery): Promise<Response<ArticleByIdDto>> {
      const response = await axios.get<Response<ArticleByIdDto>>(`${this._url}/${query.articleId}`);
      return response.data;
   }

   public async getAll(): Promise<Response<ArticlesDto[]>> {
      const response = await axios.get<Response<ArticlesDto[]>>(this._url);
      return response.data;
   }
}

