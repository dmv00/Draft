import { ITagDto, TagDto } from '../tag/dtos'

export interface IArticleByIdDto {
   title: string;
   content: string;
   created: Date;
   updated: Date;
   tags: ITagDto[]
}

export class ArticleByIdDto implements IArticleByIdDto {
   title: string;
   content: string;
   created: Date;
   updated: Date;
   tags: TagDto[];

   constructor(dto: IArticleByIdDto) {
      this.title = dto.title;
      this.content = dto.content;
      this.created = dto.created;
      this.updated = dto.updated;
      this.tags = dto.tags;
   }
}

export interface IArticlesDto {
   id: number;
   title: string;
   tags: ITagDto[];
}

export class ArticlesDto implements IArticlesDto {
   id: number;
   title: string;
   tags: TagDto[];
   constructor(dto: IArticlesDto) {
      this.id = dto.id;
      this.title = dto.title;
      this.tags = dto.tags;
   }
}