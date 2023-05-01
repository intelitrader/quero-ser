import fs from 'fs' ;

export default function readTxt(url) {

    try {  
        var data = fs.readFileSync(url, 'utf8');
        return data.toString();    
    } catch(e) {
        console.log('Error:', e.stack);
    }

}
