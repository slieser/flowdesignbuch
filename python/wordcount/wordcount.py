def split_into_words(text):
    return text.strip().split()


def filter_stopwords(words, stopwords):
    return [word for word in words if word not in stopwords]
