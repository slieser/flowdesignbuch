const expect = require("chai").expect;
const wordcount = require("../wordcount.js");

describe("wordcount.SplitIntoWords", () => {
    it("splits a string at blanks into words", () => {
        expect(wordcount.SplitTextIntoWords("a bb c ddd")).to.deep.equal(["a", "bb", "c", "ddd"])
    });
});

describe("wordcount.CountWords", () => {
    it("counts the array elements", () => {
        expect(wordcount.CountWords(["a", "a", "a", "a"])).to.equal(4)
    });
});

describe("wordcount.FilterStopwords", () => {
    it("filters the stopwords", () => {
        expect(wordcount.FilterStopwords(["a", "b", "a", "c"], ["a", "x"])).to.deep.equal(["b", "c"])
    });
});