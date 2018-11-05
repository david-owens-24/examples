from bs4 import BeautifulSoup
import requests
import time
import sys

import datetime
import MySQLdb

class updateBookClass:
    bookASIN = None
    bookLength = None
    bookFileSize = None
    bookLanguage = None
    bookPublisher = None

def updateBook(input):
    #ASIN will always be passed in. Assumed correct due to validation UI
    #also assumed that the book does exist in the database
    currentBook = updateBookClass()
    currentBook.bookASIN = input
    #formulate the URL of the book
    url = "https://www.amazon.co.uk/dp/" + input
    #get the webpage
    response = requests.get(url, headers={'User-agent': 'Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36'})
    # set the results of the scan to soup
    soup = BeautifulSoup(response.content, 'html.parser')
    # this is just the code from addBook where we go through the list to get the extra information
    currentItem = soup.find('div', {'class': 'content'})
    currentItem = currentItem.find("ul")
    for li in currentItem.find_all("li"):
        # can get a bunch of information here, number of pages is not guaranteed to be on there though so we must check to see if it is there
        # when looking for more information that could be added check this bit
        # seems that file size is always stored, as well as the language
        found = 0
        currentText = li.text
        if "Print Length:" in currentText:
            # we have found the print length string in the list
            currentBook.bookLength = currentText[14:17]
            continue
        if "File Size:" in currentText:
            # we have found the file size string in the list
            currentBook.bookFileSize = currentText[11:]
            continue
        if "Language:" in currentText:
            # we have found the language string
            currentBook.bookLanguage = currentText[10:]
            continue
        if "Publisher:" in currentText:
            # found the publisher string
            # this one is not on every page so may still be null after this loop
            currentBook.bookPublisher = currentText[11:]
            continue
    # now add the book
    db = MySQLdb.connect(host='localhost', user='root', passwd='password', db='webscrape3')
    c = db.cursor()
    # set to utf8 for foreign names and whatnot
    db.set_character_set('utf8')
    c.execute('SET NAMES utf8;')
    c.execute('SET CHARACTER SET utf8;')
    c.execute('SET character_set_connection=utf8;')
    # IMPORTANT HERE
    # if book already exists then this will not create a new record. User can choose to update the booklength and anything else added in the future
    query = """UPDATE books SET BookLength=%s, BookFileSize=%s, BookLanguage=%s, BookPublisher=%s WHERE ASIN=%s """
    try:
        c.execute(query, (currentBook.bookLength, currentBook.bookFileSize, currentBook.bookLanguage,currentBook.bookPublisher, currentBook.bookASIN))
        db.commit()
    except MySQLdb.IntegrityError as e:
        print(e)
    db.close()

#takes an ASIN as input
updateBook(sys.argv[1])