const integration = require("./integration.js");
const ui = require("./consoleui.js");

var args = process.argv;

var lines = integration.WordWrap(args);
ui.ShowResult(lines);
