from commandline import get_path
from filenameprovider import find_source_filenames
from fileprovider import read_file
from linesofcode import create_locstat


def start(args, on_locstat, on_finished):
    path = get_path(args)
    find_source_filenames(path, lambda filename: on_file(filename, on_locstat), on_finished)


def on_file(filename, on_locstat):
    lines = read_file(filename)
    locstat = create_locstat(filename, lines)
    on_locstat(locstat)
