import re


def word_wrap(text, max_length):
    paragraphs = _split_text_into_paragraphs(text)
    words_per_paragraph = _split_paragraphs_into_words(paragraphs)
    lines = _create_lines(words_per_paragraph, max_length)
    return lines


def _split_text_into_paragraphs(text):
    text = re.sub(r'\n\n+', '\n\n', text)
    return text.split('\n\n')


def _split_paragraphs_into_words(paragraphs):
    for paragraph in paragraphs:
        yield paragraph.replace('\n', ' ').split(' ')


def _create_lines(words_per_paragraph, max_length):
    for words in words_per_paragraph:
        lines = _create_lines_for_paragraph(words, max_length)
        yield from lines
        yield ''


def _create_lines_for_paragraph(words, max_length):
    line = ''
    for word in words:
        if line == '':
            line = word
        else:
            new_line = line + ' ' + word
            if len(new_line) <= max_length:
                line = new_line
            else:
                yield line
                line = word
    if line != '':
        yield line
