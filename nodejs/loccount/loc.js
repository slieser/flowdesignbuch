exports.CountLoc = function (filename, lines) {
    return {
        filename: filename,
        total: lines.length,
        loc: lines.filter(l => l !== "").length
    }
};