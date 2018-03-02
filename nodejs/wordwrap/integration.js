const commandline = require("./commandline.js");
const textfileprovider = require("./textfileprovider.js");
const wordwrap = require("./wordwrap.js");

exports.WordWrap = function(args) {
    var filename = commandline.GetFilename(args);
    var lines = textfileprovider.ReadFile(filename);
    var paragraphs = wordwrap.SplitTextIntoParagraphs(lines);
    var words = wordwrap.SplitParagraphsIntoWords(paragraphs);
    var length = commandline.GetMaxLength(args);
    var newLines = wordwrap.CreateLines(words, length);

    return newLines;
};