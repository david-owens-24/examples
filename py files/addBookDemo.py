from bs4 import BeautifulSoup
import requests
import time
import sys

import datetime
import MySQLdb

class addBookClass:
    bookTitle = None
    bookASIN = None
    bookAuthor = None
    bookURL = None
    bookPrice = None
    bookLength = None
    bookFileSize = None
    bookLanguage = None
    bookPublisher = None

def addBook(input):
    #if type = 1, then an ASIN has been passed in
    print("attempting to add book " + input)
    url = "https://www.amazon.co.uk/dp/" + input

    #pass in the url of the book
    #could do a check here to see if it is already in the database
    #include in future
    currentBook = addBookClass()
    response = requests.get(url, headers={'User-agent': 'Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36'})
    # set the results of the scan to soup
    soup = BeautifulSoup(response.content, 'html.parser')

    #url is given
    currentBook.bookURL = url

    #get title of the book
    currentItem = soup.find('span', {'class':'a-size-extra-large'})
    currentItem = currentItem.string
    currentItem = currentItem.strip()
    currentBook.bookTitle = currentItem

    #get ASIN of the book
    #will either be passed in by the URL or directly by ASIN depending on the user input
    #if url passed in

    #this bit potentially no longer relevant 26/04/2018
    if type == 1:
        index = int(url.find("/dp/"))
        currentBook.bookASIN = url[index+4:index + 14]
    else:
        #if asin is passed in
        currentBook.bookASIN = input

    #bookAuthor next
    #can be in one of two places
    currentItem = soup.find('a', {'class': 'a-link-normal contributorNameID'})
    if currentItem == None:
        currentItem = soup.find('span',{'class': 'author notFaded'})
        currentItem = currentItem.find('a', {'class': 'a-link-normal'})
    #B076CQSYMM for example of where it is not in the first position
    currentItem = currentItem.string
    currentItem = currentItem.strip()
    currentBook.bookAuthor = currentItem

    #now we go into the list to get a bunch of information
    currentItem = soup.find('div', {'class': 'content'})
    currentItem = currentItem.find("ul")
    for li in currentItem.find_all("li"):
        #can get a bunch of information here, number of pages is not guaranteed to be on there though so we must check to see if it is there
        #when looking for more information that could be added check this bit
        #seems that file size is always stored, as well as the language
        found = 0
        currentText = li.text
        if "Print Length:" in currentText:
            #we have found the print length string in the list
            currentBook.bookLength = currentText[14:17]
            continue
        if "File Size:" in currentText:
            #we have found the file size string in the list
            currentBook.bookFileSize = currentText[11:]
            continue
        if "Language:" in currentText:
            #we have found the language string
            currentBook.bookLanguage = currentText[10:]
            continue
        if "Publisher:" in currentText:
            #found the publisher string
            #this one is not on every page so may still be null after this loop
            currentBook.bookPublisher = currentText[11:]
            continue

    #from here, if it is there, it always seems to be 3rd in the list and can be found at currentItem[2].contents[1]
    #currentItem = currentItem[2].contents[1].string
    #currentItem = currentItem.strip()
    #currentItem = currentItem[:3]
    #currentBook.bookLength = currentItem

    #now add the book
    db = MySQLdb.connect(host='localhost', user='root', passwd='password', db='webscrape3')
    c = db.cursor()
    # set to utf8 for foreign names and whatnot
    db.set_character_set('utf8')
    c.execute('SET NAMES utf8;')
    c.execute('SET CHARACTER SET utf8;')
    c.execute('SET character_set_connection=utf8;')
    # IMPORTANT HERE
    # if book already exists then this will not create a new record. User can choose to update the booklength and anything else added in the future
    query = """INSERT INTO books (BookTitle, ASIN, BookAuthor, BookURL, BookLength, BookFileSize, BookLanguage, BookPublisher) VALUES (%s,%s,%s,%s,%s,%s,%s,%s)"""
    try:
        c.execute(query, (currentBook.bookTitle, currentBook.bookASIN, currentBook.bookAuthor, currentBook.bookURL, currentBook.bookLength, currentBook.bookFileSize, currentBook.bookLanguage, currentBook.bookPublisher))
        db.commit()
        print("Book successfully added")
    except MySQLdb.IntegrityError as e:
        print(e)
        if e.args[0] == 1062:
            #already in the database, may aswell update with new values since we have them
            #set new updates here
            print("Updating already existing row with new values found")
            c.execute("""UPDATE books SET BookLength=%s, BookFileSize=%s, BookLanguage=%s, BookPublisher=%s WHERE ASIN=%s """, (currentBook.bookLength, currentBook.bookFileSize,currentBook.bookLanguage, currentBook.bookPublisher, currentBook.bookASIN))
            db.commit()
    db.close()

#takes an asin as input

#addBook("B07BTQFF45")
if len(sys.argv) > 1:
    addBook(sys.argv[1])
