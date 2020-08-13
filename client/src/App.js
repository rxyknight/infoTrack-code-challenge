import React from 'react';
import { SearchRanking } from './components/SearchRanking';
import { ResultArea } from './components/ResultArea';
import { GlobalProvider } from './context/GlobalContext';

function App() {
  return (
    <GlobalProvider>
      <div className="App">
        <h2>InfoTrack code challenge</h2>
        <SearchRanking />
        <ResultArea />
      </div>
    </GlobalProvider>
  );
}

export default App;
