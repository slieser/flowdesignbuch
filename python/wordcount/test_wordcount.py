from unittest import TestCase

from wordcount import filter_stopwords, split_into_words


class WordcountTests(TestCase):
    def test_split_text_Mary_example(self):
        words = split_into_words("Mary had a little lamb.")
        self.assertEqual(words, ["Mary", "had", "a", "little", "lamb."])

    def test_split_text_multiple_blanks(self):
        words = split_into_words("a     b")
        self.assertEqual(words, ["a", "b"])

    def test_filter_one_stopword_once(self):
        filtered = filter_stopwords(["a", "b", "c"], ["b"])
        self.assertEqual(filtered, ["a", "c"])

    def test_filter_one_stopword_multiple_times(self):
        filtered = filter_stopwords(["a", "b", "b"], ["b"])
        self.assertEqual(filtered, ["a"])

    def test_filter_multiple_stopword_multiple_times(self):
        filtered = filter_stopwords(["a", "b", "a", "c", "b"], ["b", "c"])
        self.assertEqual(filtered, ["a", "a"])
