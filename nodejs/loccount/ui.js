const sumLoc = {
    filename: "",
    total: 0,
    loc: 0
};

exports.ShowLoc = function (locstat) {
    console.log(locstat.filename + " " + locstat.total + " " + locstat.loc);
    sumLoc.total += locstat.total;
    sumLoc.loc += locstat.loc;
};

exports.ShowSum = function () {
    console.log();
    console.log("Sum:");
    console.log("  Total: " + sumLoc.total)
    console.log("  LOC  : " + sumLoc.loc)
};