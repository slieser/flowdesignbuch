const readlineSync = require('readline-sync');

exports.GetText = function() {
    return readlineSync.question('Enter your text: ');
};

exports.ShowResult = function(numberOfWords) {
    console.log(`Number of words: ${numberOfWords}`);
};
