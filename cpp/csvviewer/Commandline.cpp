#include "Commandline.h"

#include <string>
#include <vector>

class Commandline {
    std::string GetFilename(std::vector<std::string> args) {
        return args[0];
    }
};
