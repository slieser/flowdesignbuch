def ReadFile(filename):
    file = open(filename, "r")
    content = file.read()
    return content.split("\n")
