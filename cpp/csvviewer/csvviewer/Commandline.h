#pragma once
#include <string>
#include <vector>

namespace csvviewer
{
    class Commandline {
    public:
        std::string GetFilename(const std::vector<std::string>& args);
        int GetPageLength(const std::vector<std::string>& args);
        int GetPageLength() const;
    private:
        int m_pageLength = 3;
    };
}