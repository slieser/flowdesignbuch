const fs = require("fs");

exports.ReadStopwords = function () {
    return fs.readFileSync("stopwords.txt").toString().split("\n")
};