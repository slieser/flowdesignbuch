const ui = require("./consoleui.js");
const interactors = require("./interactors.js");

let text = ui.GetText();
let numberOfWords = interactors.CountWords(text);
ui.ShowResult(numberOfWords);
