import fs from 'fs';
import { DIVERGENCY__PATH } from './pathConfig.js'

const writeDivergency = (text) => {

  fs.appendFile(DIVERGENCY__PATH, text + '\n', (err) => {
    if (err) {
      console.error(err);
    }
  });
}

export default writeDivergency