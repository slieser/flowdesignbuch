exports.SplitTextIntoWords = function(text) {
    return text.match(/[a-zA-Z]+/g);
}

exports.CountWords = function(words) {
    return words.length;
}

exports.FilterStopwords = function(words, stopwords) {
    return words.filter(function (word) {
        return !stopwords.includes(word);
    });
}