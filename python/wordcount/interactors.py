from stopwords_provider import read_stopwords
from wordcount import split_into_words, filter_stopwords


def start(text):
    words = split_into_words(text)
    stopwords = read_stopwords()
    filtered_words = filter_stopwords(words, stopwords)
    return len(filtered_words)
