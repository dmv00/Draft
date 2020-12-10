export interface ICreateArticleCommand {
   title: string,
   content: string
}

export interface IUpdateArticleCommand {
   articleId: number,
   title?: string,
   content?: string
}