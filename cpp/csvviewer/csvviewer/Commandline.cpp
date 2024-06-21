#include "Commandline.h"

namespace csvviewer
{
    std::string Commandline::GetFilename(const std::vector<std::string>& args)
    {
        if(args.empty())
            return "persons.csv";
        return args[0];
    }

    int Commandline::GetPageLength(const std::vector<std::string>& args)
    {
        if(args.size() > 1)
            m_pageLength = std::stoi(args[1]);
        return m_pageLength;
    }

    int Commandline::GetPageLength() const
    {
        return m_pageLength;
    }
}