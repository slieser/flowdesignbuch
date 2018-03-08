const walk = require("walk");
const path = require("path");

exports.GetSourcecodeFiles = function(directory, onFilename, onFinished) {
    let options = {
        followLinks: false
    };

    walker = walk.walk(path.resolve(directory), options);

    walker.on("file", function (root, fileStats, next) {
        let fullQualifiedName = path.join(root, fileStats.name);
        if(fullQualifiedName.endsWith(".js"))
            onFilename(fullQualifiedName);
        next();
    });

    walker.on("end", function() {
        onFinished();
    });
};
