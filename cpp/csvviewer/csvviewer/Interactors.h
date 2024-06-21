#pragma once

#include "Commandline.h"
#include "FileProvider.h"
#include "Paging.h"
#include "Record.h"

namespace csvviewer
{
    class Interactors
    {
    public:
        std::vector<Record> Start(std::vector<std::string> args);
        std::vector<Record> FirstPage();
        std::vector<Record> PrevPage();
        std::vector<Record> NextPage();
        std::vector<Record> LastPage();

    private:
        Commandline commandline;
        FileProvider fileProvider;
        Paging paging;
    };
}