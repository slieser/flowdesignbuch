import sys

from commandline import get_filename
from file_provider import read_file
from interactors import start
from ui import get_text, show_count

if __name__ == '__main__':
    filename = get_filename(sys.argv)
    if filename == "":
        text = get_text()
    else:
        text = read_file(filename)
    count = start(text)
    show_count(count)
