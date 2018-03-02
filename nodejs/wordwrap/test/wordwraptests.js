const expect = require("chai").expect;
const wordwrap = require("../wordwrap");

describe("wordwrap.CreateLines", () => {
    it("creates lines if only one word fits into each line", () => {
        expect(wordwrap.CreateLines([["1", "22", "333"]], 3)).to.deep.equal(["1", "22", "333"])
    });
    it("creates lines if two words fit into a line", () => {
        expect(wordwrap.CreateLines([["1", "22", "333"]], 4)).to.deep.equal(["1 22", "333"])
    });
    it("creates lines if one word is longer than the line length", () => {
        expect(wordwrap.CreateLines([["333", "4444"]], 2)).to.deep.equal(["333", "4444"])
    });
    it("conservs the paragraphs", () => {
        expect(wordwrap.CreateLines([["333", "1"], ["22"]], 2)).to.deep.equal(["333", "1", "", "22"])
    });
});

describe("wordwrap.SplitTextIntoParagraphs", () => {
    it("creates one paragraph for consecutive lines", () => {
        expect(wordwrap.SplitTextIntoParagraphs(["a", "b"])).to.deep.equal(["a b"])
    });
    it("creates two paragraphs for lines devided by a blank line", () => {
        expect(wordwrap.SplitTextIntoParagraphs(["a", "", "b"])).to.deep.equal(["a", "b"])
    });
    it("creates two paragraphs for multiple lines devided by a blank line", () => {
        expect(wordwrap.SplitTextIntoParagraphs(["a", "", "b", "c"])).to.deep.equal(["a", "b c"])
    });
    it("creates two multiline paragraphs", () => {
        expect(wordwrap.SplitTextIntoParagraphs(["a", "b", "", "c", "d"])).to.deep.equal(["a b", "c d"])
    });
    it("ignores multiple blank lines", () => {
        expect(wordwrap.SplitTextIntoParagraphs(["a", "", "", "b", "", "", "", "c"])).to.deep.equal(["a", "b", "c"])
    });
});

describe("wordwrap.SplitParagraphsIntoWords", () => {
    it("splits two words at a blank", () => {
        expect(wordwrap.SplitParagraphsIntoWords(["a b"])).to.deep.equal([["a", "b"]])
    });
    it("splits two words at multiple blanks", () => {
        expect(wordwrap.SplitParagraphsIntoWords(["a    b"])).to.deep.equal([["a", "b"]])
    });
    it("splits words from multiple lines", () => {
        expect(wordwrap.SplitParagraphsIntoWords(["a b", "c d"])).to.deep.equal([["a", "b"], ["c", "d"]])
    });
});
