const expect = require("chai").expect;
const rewire = require("rewire");

const wordcount = require("../wordcount.js");
const wordcountRewired = rewire("../wordcount.js")

describe("wordcount", () => {
    it("counts 'Mary had a little lamb.' as 5 words", () => {
        expect(wordcount.CountWords("Mary had a little lamb.")).to.equal(5)
    });

    it("counts 'Wörter' as 2 words", () => {
        expect(wordcount.CountWords("Wörter")).to.equal(2)
    })
});

describe("wordcount.SplitIntoWords", () => {
    const SplitIntoWords = wordcountRewired.__get__("SplitIntoWords");

    it("splits a string at blanks into words", () => {
        expect(SplitIntoWords("a bb c ddd")).to.deep.equal(["a", "bb", "c", "ddd"])
    });
});

describe("wordcount.CountWords", () => {
    const CountWords = wordcountRewired.__get__("CountWords");

    it("counts the array elements", () => {
        expect(CountWords(["a", "a", "a", "a"])).to.equal(4)
    });
});