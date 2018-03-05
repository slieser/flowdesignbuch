const ui = require("./consoleui.js");
const wordcount = require("./wordcount.js");

let text = ui.GetText();
let numberOfWords = wordcount.CountWords(text);
ui.ShowResult(numberOfWords);
