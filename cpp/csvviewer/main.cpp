#include <iostream>
#include <string>
#include <vector>

#include "Interactors.h"
#include "Record.h"
#include "Ui.h"

int main() {
    Interactors interactors;
    Ui ui;

    auto records = interactors.Start(new std::vector<std::string>());
    ui.Display(records);
    return 0;
}
