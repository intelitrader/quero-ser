import fs from 'fs';

export  class FileHandler{

     static readFile(filePath){
        let data;
        try {
            data = fs.readFileSync(filePath, 'utf8');
          } catch (err) {
            console.error(err);
          }
        return data
    }

    static writeFile (filePath,impressao){

        try {
            fs.writeFileSync(filePath, impressao);
        }catch (err) {
                console.error(err);
        }
    }
    
}