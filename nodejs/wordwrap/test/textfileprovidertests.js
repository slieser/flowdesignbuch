const expect = require("chai").expect;
const textfileprovider = require("../textfileprovider");

describe('textfileprovider.ReadFile', () => {
    it('should read the file', () => {
        expect(textfileprovider.ReadFile("test/testdaten.txt")).to.deep.equal(["first", "second"])
    });
});