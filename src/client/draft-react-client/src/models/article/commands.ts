import { ITagDto, TagDto } from "../tag/dtos";

export interface ICreateArticleCommand {
   title: string;
   content: string;
   tags: ITagDto[];
}


export class CreateArticleCommand implements ICreateArticleCommand {
   title: string;
   content: string;
   tags: TagDto[];
   constructor(command: ICreateArticleCommand) {
      this.title = command.title;
      this.content = command.content;
      this.tags = command.tags;
   }
}

export interface IUpdateArticleCommand {
   articleId: number;
   title?: string;
   content?: string;
   tags: ITagDto[];
}

export class UpdateArticleCommand implements IUpdateArticleCommand {
   articleId: number;
   title?: string;
   content?: string;
   tags: TagDto[];

   constructor(command: IUpdateArticleCommand) {
      this.articleId = command.articleId;
      this.title = command.title;
      this.content = command.content;
      this.tags = command.tags;
   }

}