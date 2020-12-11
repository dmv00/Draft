import React from 'react';
import { ArticlesClient } from '../api-client';

const articleClient = new ArticlesClient();
const result = articleClient.create({ title: "Client Test Article", content: "some data" });
console.log(result);
function App() {
  return (
    <div>

    </div>
  );
}

export default App;
