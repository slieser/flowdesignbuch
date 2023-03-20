#ifndef CSVVIEWER_PAGING_H
#define CSVVIEWER_PAGING_H

#include "Record.h"
#include <vector>

class Paging {
    std::vector<Record> ExtractFirstPage(std::vector<Record> records);
};


#endif //CSVVIEWER_PAGING_H
