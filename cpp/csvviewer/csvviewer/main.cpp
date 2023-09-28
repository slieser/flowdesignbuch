#include <iostream>
#include <string>
#include <vector>

#include "Interactors.h"
#include "Record.h"
#include "Ui.h"

using namespace csvviewer;

int main(int argc, char* argv[]) {
    Interactors interactors;
    Ui ui;
    ui.MoveFirst = [&] {
        auto records = interactors.FirstPage();
        ui.Display(records);
    };
    ui.MovePrev = [&] {
        auto records = interactors.PrevPage();
        ui.Display(records);
    };
    ui.MoveNext = [&] {
        auto records = interactors.NextPage();
        ui.Display(records);
    };
    ui.MoveLast = [&] {
        auto records = interactors.LastPage();
        ui.Display(records);
    };

    {
        auto records = interactors.Start({argv+1, argv+argc});
        ui.Display(records);
    }
    ui.Run();
    return 0;
}
