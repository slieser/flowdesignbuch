const expect = require("chai").expect;
const interactors = require("../interactors");

describe('interactors.Start', () => {
    it('should wrap the text', () => {
        expect(interactors.Start(["", "", "test/testdaten.txt", 20]))
            .to.deep.equal(["first second"])
    });
    it('should retain the paragraphs', () => {
        expect(interactors.Start(["", "", "test/multipleparagraphs.txt", 20]))
            .to.deep.equal([
                "This is the first",
                "paragraph.",
                "",
                "This is the second",
                "paragraph.",
                "",
                "And here is the",
                "third."])
    });
});
