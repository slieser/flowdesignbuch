const wordcount = require("./wordcount.js");
const stopwordsprovider = require("./stopwordsprovider.js");

exports.Start = function(text) {
    let words = wordcount.SplitTextIntoWords(text);
    let stopwords = stopwordsprovider.ReadStopwords();
    let filteredWords = wordcount.FilterStopwords(words, stopwords);
    let numberOfWords = wordcount.CountWords(filteredWords);
    return numberOfWords;
};
