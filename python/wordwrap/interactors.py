from textfileprovider import read_file
from commandline import get_filename, get_max_length
from wordwrap import word_wrap


def start(argv):
    filename = get_filename(argv)
    max_length = get_max_length(argv)
    text = read_file(filename)
    lines = word_wrap(text, max_length)
    return lines