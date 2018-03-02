const expect = require("chai").expect;
const commandline = require("../commandline.js");

describe("commandline.GetFilename", () => {
    it("gets the filename", () => {
        expect(commandline.GetFilename(["", "", "x.txt"])).to.equal("x.txt")
    });
});

describe("commandline.GetMaxLength", () => {
    it("gets the max length", () => {
        expect(commandline.GetMaxLength(["", "", "", "42"])).to.equal("42")
    })
});
