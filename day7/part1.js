import * as fs from "fs";

function Node(name, size){
  this.name = name;
  this.size = size || 0;
  this.children = [];
  this.parent = null;
}

function Graph(){
  this.root = new Node("/");
  this.current = this.root;

  this.traverseTo = (ch) => {
    this.current = this.current[ch];
  };

  this.addNode = (node) => {0
    this.current.children.push(node);
  }
}

export default function solve() {
  const graph = new Graph();
  
  let count = 0;
  for (const line of fs.readFileSync("input.txt", "utf-8").split(/\r?\n/)) {
    if (line[0] == "$") {
      if (line[2] == "c") {
        graph.traverseTo(line[5]);
      }
    } else if (line[0] == "d")
  }

  console.log(count);
}