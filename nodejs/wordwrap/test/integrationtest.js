const expect = require("chai").expect;
const integration = require("../integration");

describe('integration.WordWrap', () => {
    it('should wrap the text', () => {
        expect(integration.WordWrap(["", "", "test/testdaten.txt", 20]))
            .to.deep.equal(["first second"])
    });
    it('should retain the paragraphs', () => {
        expect(integration.WordWrap(["", "", "test/multipleparagraphs.txt", 20]))
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