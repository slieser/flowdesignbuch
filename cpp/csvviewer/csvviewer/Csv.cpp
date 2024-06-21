#include "Csv.h"
#include <sstream>

namespace csvviewer
{
    std::vector<std::string> Split(const std::string& line, char sep);

    std::vector<Record> Csv::CreateRecords(const std::vector<std::string>& lines) {
        std::vector<Record> records;
        for(const auto& l : lines)
        {
            auto values = Split(l, ';');
            records.push_back({std::move(values)});
        }
        return records;
    }

    std::vector<std::string> Split(const std::string& line, char sep)
    {
        std::stringstream ss(line);
        std::vector<std::string> parts;
        std::string part;
        while(std::getline(ss, part, sep))
            parts.emplace_back(std::move(part));
        return parts;
    }
}