#pragma once
#include <string>
#include <vector>

namespace csvviewer
{
    class Paging {
    public:
        std::vector<std::string> ExtractFirstPage(const std::vector<std::string>& lines, int pageLength);
        std::vector<std::string> ExtractPrevPage(const std::vector<std::string>& lines, int pageLength);
        std::vector<std::string> ExtractNextPage(const std::vector<std::string>& lines, int pageLength);
        std::vector<std::string> ExtractLastPage(const std::vector<std::string>& lines, int pageLength);

    private:
        void IncrementPageNo(const std::vector<std::string>& lines, int pageLength);
        void DecrementPageNo();
        int pageNo = 1;
    };
}