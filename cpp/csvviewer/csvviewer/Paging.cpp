#include "Paging.h"

namespace csvviewer 
{
    int CalculateLastPageNo(const std::vector<std::string>& lines, int pageLength);
    int CalculateLinesToSkip(int pageNo, int pageLength);
    std::vector<std::string> ExtractLinesForPage(const std::vector<std::string>& lines, int pageLength, int linesToSkip);

    std::vector<std::string> Paging::ExtractFirstPage(const std::vector<std::string>& lines, int pageLength)
    {
        pageNo = 1;
        auto linesToSkip = CalculateLinesToSkip(pageNo, pageLength);
        return ExtractLinesForPage(lines, pageLength, linesToSkip);
    }

    std::vector<std::string> Paging::ExtractPrevPage(const std::vector<std::string>& lines, int pageLength)
    {
        DecrementPageNo();
        auto linesToSkip = CalculateLinesToSkip(pageNo, pageLength);
        return ExtractLinesForPage(lines, pageLength, linesToSkip);
    }

    std::vector<std::string> Paging::ExtractNextPage(const std::vector<std::string>& lines, int pageLength)
    {
        IncrementPageNo(lines, pageLength);
        auto linesToSkip = CalculateLinesToSkip(pageNo, pageLength);
        return ExtractLinesForPage(lines, pageLength, linesToSkip);
    }

    std::vector<std::string> Paging::ExtractLastPage(const std::vector<std::string>& lines, int pageLength)
    {
        pageNo = CalculateLastPageNo(lines, pageLength);
        auto linesToSkip = CalculateLinesToSkip(pageNo, pageLength);
        return ExtractLinesForPage(lines, pageLength, linesToSkip);
    }

    void Paging::IncrementPageNo(const std::vector<std::string>& lines, int pageLength)
    {
        if(pageNo < CalculateLastPageNo(lines, pageLength)) {
            ++pageNo;
        }
    }

    void Paging::DecrementPageNo()
    {
        if(pageNo > 1) {
            --pageNo;
        }
    }

    int CalculateLastPageNo(const std::vector<std::string>& lines, int pageLength)
    {
        // - 1 for the header 
        int numDataSets = static_cast<int>(lines.size()) - 1;
        // -1 because lines=10 pageLength=3 => lastPage=3 and not 4
        // 1 + because pageNo starts with 1 not 0
        return 1+ std::max(numDataSets - 1, 0) / pageLength;
    }

    int CalculateLinesToSkip(int pageNo, int pageLength)
    {
        // 1 + because skip the header line every time
        return 1 + (pageNo - 1) * pageLength;
    }

    std::vector<std::string> ExtractLinesForPage(const std::vector<std::string>& lines, int pageLength, int linesToSkip)
    {
        std::vector<std::string> result;
        result.push_back(lines.front());
        auto last = linesToSkip + pageLength > lines.size() ? end(lines) : begin(lines) + linesToSkip + pageLength;
        result.insert(begin(result)+1, begin(lines)+linesToSkip, last);
        return result;
    }
}