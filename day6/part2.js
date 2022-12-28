import * as fs from "fs";

export default function solve() {
  let stream = "";
  for (const line of fs.readFileSync("input.txt", "utf-8").split(/\r?\n/)) {
    stream = line;
  }

  const marker = [];
  for (let i = 0; i < stream.length; i++) {
    const ch = stream[i];
    const idx = marker.indexOf(ch);
    if (idx != -1) {
      for (let j = 0; j <= idx; j++) {
        marker.shift();
      }
    }
    
    if (marker.length == 13) {
      console.log("idx>>>", i + 1);
      break;
    }
    marker.push(ch);
  }
}