import fs from "fs";

export default function criaPasta(cn) {
  fs.mkdir("./Saida/" + cn, { recursive: true }, (err) => {
    if (err) throw err;
    console.log("Pasta criada");
  });
}
