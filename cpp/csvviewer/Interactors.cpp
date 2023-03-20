#include "Interactors.h"
#include "Commandline.h"
#include "FileProvider.h"
#include "Csv.h"
#include "Record.h"
#include "Paging.h"

#include <string>
#include <vector>

class Interactors {
    void Interactors::Start(std::vector<std::string> args) {
        Commandline commandline;
        FileProvider fileProvider;
        Csv csv;
        Paging paging;

        auto filename = commandline.GetFilename(args);
        auto lines = fileProvider.ReadFile(filename);
        auto records = csv.CreateRecords(lines);
        return paging.ExtractFirstPage(records);
    }
};