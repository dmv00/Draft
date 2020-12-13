export interface IArticleByIdDto {
   title: string;
   content: string;
   created: Date;
}

export class ArticleByIdDto {
   title: string;
   content: string;
   created: Date;

   constructor(dto: IArticleByIdDto) {
      this.title = dto.title;
      this.content = dto.content;
      this.created = dto.created;
   }
}

export interface IArticlesDto {
   id: number;
   title: string;
}

export class ArticlesDto {
   id: number;
   title: string;

   constructor(dto: IArticlesDto) {
      this.id = dto.id;
      this.title = dto.title;
   }
}