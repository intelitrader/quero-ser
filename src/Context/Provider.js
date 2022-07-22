import React from 'react';
import MyContext from './MyContext';

function Provider({children}) {
  const context = {

  };
  return (
    <MyContext.Provider value={ context }>
      { children }
    </MyContext.Provider>
  );
}

export default Provider;
