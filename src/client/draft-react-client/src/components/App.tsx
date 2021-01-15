import React, { useEffect, useState } from 'react';
import { ArticlesClient } from '../api-client';
import { ArticlesDto } from '../models/article/dtos';
import { Article } from './Article';

export const App: React.FC = () => {
  const [articles, setArticles] = useState<ArticlesDto[]>([]);
  const [error, setError] = useState(false);
  const articleClient = new ArticlesClient();

  useEffect(() => {
    getAllArticles();
  }, [])
  async function getAllArticles() {
    try {
      const respose = await articleClient.getAll();
      if (respose.errors.length > 0) {
        console.log(respose.errors);
        setError(true);
        return;
      }
      setArticles(respose.data);
    } catch (error) {
      setError(true);
    }
  }
  if (error) {
    return <p>Something went wrong...</p>
  } else {
    return (
      <div>
        {articles.map(article => {
          return <Article article={article} key={article.id} />
        })}
      </div>
    );
  }
}