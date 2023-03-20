#ifndef CSVVIEWER_COMMANDLINE_H
#define CSVVIEWER_COMMANDLINE_H

#include <string>
#include <vector>

class Commandline {
    std::string GetFilename(std::vector<std::string> args);
};


#endif //CSVVIEWER_COMMANDLINE_H
