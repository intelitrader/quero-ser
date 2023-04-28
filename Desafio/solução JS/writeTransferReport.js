import fs from 'fs';
import { TRANSFER__REPORT__PATH } from './pathConfig.js'

const writeTransferReport = (text) => {

  fs.appendFile(TRANSFER__REPORT__PATH, text, (err) => {
    if (err) {
      console.error(err);
    }
  });
}

export default writeTransferReport