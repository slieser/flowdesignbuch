const commandline = require("./commandline");
const filesystemprovider = require("./filesystemprovider");
const codefileprovider = require("./codefileprovider");
const loc = require("./loc");
const ui = require("./ui");

const path = commandline.GetPath(process.argv);

filesystemprovider.FindSourceFilenames(path,
    filename => {
        let lines = codefileprovider.ReadFile(filename);
        let locstat = loc.CountLoc(filename, lines);
        ui.ShowLoc(locstat);
    },
    () => {
        ui.ShowSum();
    }
);


filesystemprovider.FindSourceFilenames(path,
    filename => {
        console.log(filename)
    },
    () => {
        console.log("Finished!")
    }
);