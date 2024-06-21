#include "FileProvider.h"
#include <fstream>

namespace csvviewer
{
    std::vector<std::string> FileProvider::ReadFileContent(const std::string& filename) {
        std::ifstream file(filename);
        std::string line;
        while(std::getline(file, line))
            lines.emplace_back(std::move(line));
        return lines;
    }

    std::vector<std::string> FileProvider::GetFileContent()
    {
        return lines;
    }
}