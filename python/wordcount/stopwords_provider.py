def read_stopwords():
    with open("stopwords.txt", "r") as f:
        return [x.strip() for x in f.readlines()]