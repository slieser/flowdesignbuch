#pragma once

#include <string>
#include <vector>

namespace csvviewer
{
    class FileProvider
    {
    public:
        std::vector<std::string> ReadFileContent(const std::string& filename);
        std::vector<std::string> GetFileContent();

    private:
        std::vector<std::string> lines;
    };
}