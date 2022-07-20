import { getBorderCharacters } from "table";
import fs from "fs";

export const config = (border, column, header) => {
  if (header) {
    return {
      border: getBorderCharacters(border),
      columnDefault: { ...column },
      header: { ...header },
    };
  } else {
    return {
      border: getBorderCharacters(border),
      columnDefault: { ...column },
    };
  }
};

export const writeFileTxt = (filename, output) =>
  fs.writeFile(filename, output.tableInfo, "utf8", (err) => {
    if (err) return console.log(err);
    console.log(output.message);
  });

export const fileReader = (caminho) =>
  fs
    .readFileSync(caminho, "utf-8", (error, data) => {
      if (error) console.log("Reading file failed" + error);
      return data;
    })
    .split("\n");
