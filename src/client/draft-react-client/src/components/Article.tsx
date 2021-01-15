import React from 'react'
import { ArticlesDto } from '../models/article/dtos';

interface Props {
   article: ArticlesDto;
}
export const Article: React.FC<Props> = ({ article }) => {
   return (
      <div>
         <h1>{article.title}</h1>
         <p>Article id: {article.id}</p>
         <p>Tags:</p>
         {article.tags.map(tag => <p>{tag.content}</p>)}
         <hr />
      </div>)
}