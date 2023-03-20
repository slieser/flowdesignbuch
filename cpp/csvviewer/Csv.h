#ifndef CSVVIEWER_CSV_H
#define CSVVIEWER_CSV_H

#include <string>
#include <vector>
#include "Record.h"

class Csv {
    std::vector<Record> CreateRecords(std::vector<std::string> lines);
};


#endif //CSVVIEWER_CSV_H
