def create_locstat(filename, lines):
    total = len(lines)
    loc = len([line for line in lines if is_loc(line)])
    result = (filename, total, loc)
    return result


def is_loc(line):
    return (line.lstrip() != "") & (not line.lstrip().startswith("#"))
