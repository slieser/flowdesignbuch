exports.SplitTextIntoParagraphs = function(lines) {
    let paragraph = "";
    let paragraphs = [];
    lines.forEach(line => {
        if(line !== "") {
            if(paragraph === "")
                paragraph = line;
            else
                paragraph += " " + line;
        }
        else if(paragraph !== "") {
            paragraphs.push(paragraph);
            paragraph = "";
        }
    });
    if(paragraph !== "") {
        paragraphs.push(paragraph);
    }
    return paragraphs;
};

exports.SplitParagraphsIntoWords = function(paragraphs) {
    let words = [];
    paragraphs.forEach(paragraph => {
        let wordsOfParagraph = [];
        paragraph.split(" ")
            .filter(w => w !== "")
            .forEach(word =>
                wordsOfParagraph.push(word));
        words.push(wordsOfParagraph);
    });
    return words;
};

exports.CreateLines = function(paragraphs, length) {
    let lines = [];
    let line = "";

    paragraphs.forEach(paragraph => {
        if(lines.length > 0) {
            lines.push("");
        }
        paragraph.forEach(word => {
            let newline = line + " " + word;
            if(line === "")
                line = word;
            else if(newline.length <= length)
                line = newline
            else {
                lines.push(line);
                line = word;
            }
        });
        if(line !== "") {
            lines.push(line);
            line = "";
        }
    });

    return lines;
};