#pragma once

#include "Record.h"
#include <vector>
#include <functional>
namespace csvviewer 
{
    class Ui {
    public:
        void Run();
        void Display(const std::vector<Record>& records);

        std::function<void()> MoveFirst;
        std::function<void()> MovePrev;
        std::function<void()> MoveNext;
        std::function<void()> MoveLast;

        static std::vector<std::string> CreateLines(const std::vector<Record>& records);
    };
}