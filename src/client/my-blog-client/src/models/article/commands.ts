export interface ICreateArticleCommand {
   title: string,
   content: string
}


export class CreateArticleCommand implements ICreateArticleCommand {
   title: string;
   content: string;
   constructor(command: ICreateArticleCommand) {
      this.title = command.title;
      this.content = command.content;
   }
}

export interface IUpdateArticleCommand {
   articleId: number,
   title?: string,
   content?: string
}

export class UpdateArticleCommand implements IUpdateArticleCommand{
   articleId: number;
   title?: string | undefined;
   content?: string | undefined;

   constructor(command : IUpdateArticleCommand){
      this.articleId = command.articleId;
      this.title = command.title;
      this.content = command.content;
   }

}