from argparse import ArgumentParser

def get_filename():
    parser = ArgumentParser()
    parser.add_argument("-f", "--file", dest="filename",
                        help="filename of CSV file", metavar="FILE")
    args = parser.parse_args()
    return args.filename
