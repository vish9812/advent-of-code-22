import * as fs from "fs";

// 2-4,6-8
// 2-3,4-5
// 5-7,7-9
// 2-8,3-7
// 6-6,4-6
// 2-6,4-8

export default function solve() {
  let count = 0;
  for (const line of fs.readFileSync("input.txt", "utf-8").split(/\r?\n/)) {
    const pairs = line.split(",");
    const p1 = pairs[0].split("-");
    const p2 = pairs[1].split("-");
    const a = +p1[0];
    const b = +p1[1];
    const c = +p2[0];
    const d = +p2[1];
    
    if ((a >= c && a <= d)
      || (b >= c && b <= d)
      || (c >= a && c <= b)
      || (d >= a && d <= b)) {
      count++;
    }
  }

  console.log(count);
}