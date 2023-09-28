#include "Interactors.h"
#include "Csv.h"

namespace csvviewer 
{
    std::vector<Record> Interactors::Start(std::vector<std::string> args) {
        auto filename = commandline.GetFilename(args);
        auto pageLength = commandline.GetPageLength(args);
        auto lines = fileProvider.ReadFileContent(filename);
        auto firstPage = paging.ExtractFirstPage(lines, pageLength);
        auto records = Csv::CreateRecords(firstPage);
        return records;
    }

    std::vector<Record> Interactors::FirstPage() {
        auto pageLength = commandline.GetPageLength();
        auto lines = fileProvider.GetFileContent();
        auto firstPage = paging.ExtractFirstPage(lines, pageLength);
        auto records = Csv::CreateRecords(firstPage);
        return records;
    }

    std::vector<Record> Interactors::PrevPage() {
        auto pageLength = commandline.GetPageLength();
        auto lines = fileProvider.GetFileContent();
        auto prevPage = paging.ExtractPrevPage(lines, pageLength);
        auto records = Csv::CreateRecords(prevPage);
        return records;
    }

    std::vector<Record> Interactors::NextPage() {
        auto pageLength = commandline.GetPageLength();
        auto lines = fileProvider.GetFileContent();
        auto nextPage = paging.ExtractNextPage(lines, pageLength);
        auto records = Csv::CreateRecords(nextPage);
        return records;
    }

    std::vector<Record> Interactors::LastPage() {
        auto pageLength = commandline.GetPageLength();
        auto lines = fileProvider.GetFileContent();
        auto lastPage = paging.ExtractLastPage(lines, pageLength);
        auto records = Csv::CreateRecords(lastPage);
        return records;
    }
}