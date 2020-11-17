const expect = require("chai").expect;
const interactors = require("../interactors.js");

describe("interactors.Start", () => {
    it("counts 'Mary had a little lamb.' as 4 words", () => {
        expect(interactors.Start("Mary had a little lamb.")).to.equal(4)
    });

    it("counts 'Wörter' as 2 words", () => {
        expect(interactors.Start("Wörter")).to.equal(2)
    })
});
