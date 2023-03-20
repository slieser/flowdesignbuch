#include <iostream>
#include <string>
#include <vector>

#include "Ui.h"
#include "Record.h"

void Ui::Display(std::vector<Record> records) {
    for(int i = 0; i < records.size(); i++) {
        for(int j = 0; j < records[i].Values.size(); j++) {
            std::cout << records[i].Values[j];
        }
        std::cout << "\n";
    }
}
