from args import get_filename
from csv_reader import create_records
from file_provider import read_file
from paging import extract_first_page


def start():
    filename = get_filename()
    lines = read_file(filename)
    all_records = create_records(lines)
    records = extract_first_page(all_records)
    return records
