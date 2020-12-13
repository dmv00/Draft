export interface IGetArticleByIdQuery {
   articleId: number
}

export class GetArticleByIdQuery implements IGetArticleByIdQuery {
   articleId: number;
   constructor(query: IGetArticleByIdQuery) {
      this.articleId = query.articleId;
   }
}
