const ui = require("./consoleui.js");
const interactors = require("./interactors.js");

let text = ui.GetText();
let numberOfWords = interactors.Start(text);
ui.ShowResult(numberOfWords);
