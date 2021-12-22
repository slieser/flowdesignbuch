def show(records):
    lines = tabellieren(records)
    for line in lines:
        print(line)
    print("F)irst P)rev N)ext L)ast E)xit")


def run():
    exit = False
    while not exit:
        ch = input()
        if ch == "e":
            exit = True
        elif ch == "n":
            print("next")


def tabellieren(records):
    if len(records) == 0:
        return []

    widths = calculate_column_widths(records)

    result = []
    for record in records:
        result.append(separator_line(widths))
        result.append(format_values(record, widths))

    result.append(separator_line(widths))
    return result


def calculate_column_widths(records):
    result = [0] * len(records[0].Values)
    for record in records:
        i = 0
        for value in record.Values:
            if len(value) > result[i]:
                result[i] = len(value)
            i += 1
    return result


def format_values(record, widths):
    s = ""
    i = 0
    for value in record.Values:
        s += "|" + value.ljust(widths[i])
        i += 1
    s += "|"
    return s


def separator_line(widths):
    s = ""
    for width in widths:
        s += "+" + "-" * width
    s += "+"
    return s
