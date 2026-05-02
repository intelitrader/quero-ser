import fs from 'fs';

const readFile = (filePath) => {
  return new Promise((resolve, reject) => {
    fs.readFile(filePath, 'utf8', function (err, data) {
      if (err) {
        reject(err);
      }
      const dataFilter = (line) => line !== ''
      const dataArray = data.split('\r\n').filter(dataFilter);
      resolve(dataArray);
    });
  });
};

const readFiles = async (DATA__PATH) => {
  let files = {}
  for (const [key, value] of Object.entries(DATA__PATH)) {
    await readFile(value)
      .then(data => {
          files[key] = data
      })
      .catch(console.error)
  };
  return files
}
export default readFiles