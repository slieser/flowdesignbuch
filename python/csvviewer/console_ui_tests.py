import unittest

from record import Record
from console_ui import tabellieren, calculate_column_widths, separator_line


class TestTabellieren(unittest.TestCase):

    def test_empty_list(self):
        result = tabellieren([])
        self.assertEqual([], result)

    def test_one_record_with_one_value(self):
        result = tabellieren([Record(["value"])])
        self.assertEqual(["+-----+", "|value|", "+-----+"], result)

    def test_one_record_with_three_values(self):
        result = tabellieren([Record(["a", "bb", "ccc"])])
        self.assertEqual(["+-+--+---+", "|a|bb|ccc|", "+-+--+---+"], result)

    def test_two_records_with_three_values(self):
        result = tabellieren([Record(["a", "bb", "ccc"]), Record(["aaa", "b", "cc"])])
        self.assertEqual(["+---+--+---+", "|a  |bb|ccc|", "+---+--+---+", "|aaa|b |cc |", "+---+--+---+"], result)

    def test_umlaute(self):
        result = tabellieren([Record(["Name", "Alter", "Ort"]), Record(["Mary", "35", "München"])])
        self.assertEqual(["+----+-----+-------+", "|Name|Alter|Ort    |", "+----+-----+-------+", "|Mary|35   |München|", "+----+-----+-------+"], result)

    def test_column_width(self):
        result = calculate_column_widths([Record(["Name", "Alter", "Ort"]), Record(["Mary", "35", "München"])])
        self.assertEqual([4, 5, 7], result)

    def test_separator_line(self):
        result = separator_line([4, 5, 7])
        self.assertEqual("+----+-----+-------+", result)