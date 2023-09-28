#pragma once
#include <string>
#include <vector>
#include "Record.h"

namespace csvviewer
{
    class Csv {
    public:
        static std::vector<Record> CreateRecords(const std::vector<std::string>& lines);
    };
}