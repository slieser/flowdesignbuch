#include "FileProvider.h"

#include <File>
#include <string>
#include <vector>

class FileProvider {
    std::vector<std::string> ReadFile(std::string filename) {
        return File::ReadAllLines(filename);
    }
};
