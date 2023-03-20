#ifndef CSVVIEWER_FILEPROVIDER_H
#define CSVVIEWER_FILEPROVIDER_H

#include <string>
#include <vector>

class FileProvider {
    std::vector<std::string> ReadFile(std::string filename);
};


#endif //CSVVIEWER_FILEPROVIDER_H
