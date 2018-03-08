const fs = require("fs");

exports.ReadFile = function (filename) {
    return fs.readFileSync(filename).toString().split("\n")
};