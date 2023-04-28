import fs from 'fs';
import { SALES__CHANNEL__REPORT__PATH } from './pathConfig.js'

const writeChannelReport = (text) => {

  fs.appendFile(SALES__CHANNEL__REPORT__PATH, text, (err) => {
    if (err) {
      console.error(err);
    }
  });
}

export default writeChannelReport