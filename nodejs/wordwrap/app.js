const interactors = require("./interactors.js");
const ui = require("./consoleui.js");

var args = process.argv;
var lines = interactors.Start(args);
ui.ShowResult(lines);
