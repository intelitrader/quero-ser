import fs from 'fs';
import {
  DIVERGENCY__PATH,
  SALES__CHANNEL__REPORT__PATH,
  TRANSFER__REPORT__PATH
} from "./pathConfig.js";

const clearReports = () => {
  fs.writeFile(DIVERGENCY__PATH, '', (err) => {
    if (err) {
      console.error(err);
    }
  });

  fs.writeFile(SALES__CHANNEL__REPORT__PATH, '', (err) => {
    if (err) {
      console.error(err);
    }
  });

  fs.writeFile(TRANSFER__REPORT__PATH, '', (err) => {
    if (err) {
      console.error(err);
    }
  });
}

export default clearReports