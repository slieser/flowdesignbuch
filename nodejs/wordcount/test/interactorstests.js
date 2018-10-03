const expect = require("chai").expect;
const interactors = require("../interactors.js");

describe("interactors", () => {
    it("counts 'Mary had a little lamb.' as 4 words", () => {
        expect(interactors.CountWords("Mary had a little lamb.")).to.equal(4)
    });

    it("counts 'Wörter' as 2 words", () => {
        expect(interactors.CountWords("Wörter")).to.equal(2)
    })
});
