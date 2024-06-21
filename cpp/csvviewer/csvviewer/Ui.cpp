#include "Ui.h"
#include <iostream>
#include <sstream>
#include <conio.h>

namespace csvviewer
{
    using namespace std;
    using Lines = vector<string>;
    using Records = vector<Record>;
    using MaxColumnWidths = vector<int>;
    vector<string> Split(string , char);
    MaxColumnWidths CalculateMaxColumnWidths(Records const& csvRecords);
    Records PadRecords(Records csvRecords, MaxColumnWidths const& maxColWidths);
    Lines AddFormatting(Records const& csvRecords, MaxColumnWidths const& maxColWidths);
    void WriteLines(Lines const& lines);

    void Ui::Run() {
        bool exit = false;
        do {
            std::cout << "\nF)irst, P)rev, N)ext, L)ast, E)xit\n";
            char key = _getch();
            switch (key) {
                case 'E':
                case 'e':
                    exit = true;
                    break;
                case 'F':
                case 'f':
                    MoveFirst();
                    break;
                case 'P':
                case 'p':
                    MovePrev();
                    break;
                case 'N':
                case 'n':
                    MoveNext();
                    break;
                case 'L':
                case 'l':
                    MoveLast();
                    break;
            }
        } while(!exit);    
    }

    void Ui::Display(const Records& records) {
        auto lines = CreateLines(records);
        WriteLines(lines);
    }

    Lines Ui::CreateLines(const Records& records)
    {
        auto maxColWidths = CalculateMaxColumnWidths(records);
        auto paddedRecords = PadRecords(records, maxColWidths);
        return AddFormatting(paddedRecords, maxColWidths);
    }

    MaxColumnWidths CalculateMaxColumnWidths(const Records& csvRecords)
    {
        MaxColumnWidths maxColWidths(csvRecords.front().Values.size(), 0);
        for (const auto& row : csvRecords) {
            int i = 0;
            for (const auto& col : row.Values) {
                if (col.length() > maxColWidths[i])
                    maxColWidths[i] = col.length();
                ++i;
            }
        }
        return maxColWidths;
    }

    Records PadRecords(Records csvRecords, const MaxColumnWidths& maxColWidths)
    {
        for (auto& row : csvRecords) {
            int i = 0;
            for (auto& col : row.Values)
                col.resize(maxColWidths[i++], ' ');
        }
        return csvRecords;
    }

    Lines AddFormatting(const Records& csvRecords, const MaxColumnWidths& maxColWidths)
    {
        vector<string> formattedLines;
        for(auto const& row : csvRecords) {
            formattedLines.push_back({});
            for(auto const& col : row.Values) {
                formattedLines.back() += col + '|';
            }
            formattedLines.back().pop_back();
        }
        string seperator;
        for(int w : maxColWidths)
            seperator += string(w, '-') + '+';
        seperator.pop_back();
        formattedLines.insert(begin(formattedLines) + 1, seperator);
        return formattedLines;
    }


    vector<string> Split(string text, char sep) {
        stringstream ss(text);
        vector<string> result;
        string part;
        while(getline(ss, part, sep))
            result.push_back(move(part));
        return result;
    }

    void WriteLines(const Lines& lines)
    {
        for(const auto& l : lines)
            std::cout << l << '\n';
    }
}