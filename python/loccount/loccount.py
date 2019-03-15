import sys

from consoleui import ShowLocStat, ShowTotal
from interactors import start


def main():
    start(sys.argv, ShowLocStat, ShowTotal)

if __name__ == "__main__":
    main()

