def read_file(filename):
    lines = [line.rstrip() for line in open(filename)]
    return lines
