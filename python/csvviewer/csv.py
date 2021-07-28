from record import Record

def create_records(lines):
    result = []
    for line in lines:
        values = line.split(';')
        record = Record(values)
        result.append(record)
    return result
