export class ArticleByIdDto {
   public title: string;
   public content: string;
   public created: Date;

   constructor(title: string, content: string, created: Date) {
      this.title = title;
      this.content = content;
      this.created = created
   }
}

export class ArticlesDto {
   public id: number;
   public title: string;

   constructor(id: number, title: string) {
      this.id = id;
      this.title = title;
   }
}