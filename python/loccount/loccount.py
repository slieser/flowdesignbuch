import sys

from consoleui import ConsoleUi
from interactors import start


def main():
    ui = ConsoleUi()
    start(sys.argv, ui.show_loc, ui.show_sum)


if __name__ == "__main__":
    main()
