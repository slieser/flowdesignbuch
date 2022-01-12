import sys

from consoleui import show
from interactors import start


def main():
    text = start(sys.argv)
    show(text)


if __name__ == '__main__':
    main()
