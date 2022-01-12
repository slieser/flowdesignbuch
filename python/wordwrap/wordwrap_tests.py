from unittest import TestCase

from wordwrap import word_wrap


class WordWrapTests(TestCase):
    def test_word_wrap_simple_words(self):
        result = list(word_wrap('a b c', 3))
        self.assertEqual(['a b', 'c', ''], result)

    def test_word_wrap_long_words(self):
        result = list(word_wrap('abc abcd abcde', 3))
        self.assertEqual(['abc', 'abcd', 'abcde', ''], result)

    def test_word_wrap_paragraphs(self):
        result = list(word_wrap('a\n\nb\n\n\nc\n\n\n\n\nd', 3))
        self.assertEqual(['a', '', 'b', '', 'c', '', 'd', ''], result)
