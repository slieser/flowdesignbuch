exports.CountWords = function(text) {
    let words = SplitTextIntoWords(text);
    let numberOfWords = CountWords(words);
    return numberOfWords;
};

function SplitTextIntoWords(text) {
    return text.match(/[a-zA-Z]+/g);
}

function CountWords(words) {
    return words.length;
}
