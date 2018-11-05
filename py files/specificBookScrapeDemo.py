from bs4 import BeautifulSoup
from addBookDemo import addBook
from addBookDemo import addBookClass
import requests
import time
import sys
import os


import datetime
import MySQLdb

class specificBookResultsClass:
    bookASIN = ""
    bookPrice = ""
    bookRank = ""
    bookReviewScore = ""
    bookNumOfReviews = ""
    bookDateOfScan = ""
    bookTimeOfScan = ""


def specificBookTop100Scrape(input):
    #need to first check whether ASIN or URL input
    # if type = 1, then an ASIN has been passed in
    asin = ""
    asin = input
    #and then check the ASIN against the database to check that it the book already exists
    db = MySQLdb.connect(host='localhost', user='root', passwd='password', db='webscrape3')
    c = db.cursor()
    # set to utf8 for foreign names and whatnot
    db.set_character_set('utf8')
    c.execute('SET NAMES utf8;')
    c.execute('SET CHARACTER SET utf8;')
    c.execute('SET character_set_connection=utf8;')
    c.execute("""SELECT BOOKID FROM books WHERE ASIN = %s """,(asin,))
    #check if something is retrieved
    row_count = c.rowcount
    db.close()
    if row_count == 0:
        # if it doesn't exist then we can use the addBook() subroutine to add it
        print("Book not found in database. Attempting to add...")
        #check if the url is valid, removed for purposes of demonstration
        checkURL = 'https://www.amazon.co.uk/dp/' + asin
        response = requests.get(checkURL, headers={'User-agent': 'Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36'})
        soup = BeautifulSoup(response.content, 'html.parser')
        #need to sleep for 1 if the webpage was correct
        #the not found page on amazon currently has a td with class name sans, check if this exists, otherwise continue
        checkFail = soup.find("td",{"class":"sans"})
        #checkFail will now be None if the webpage was incorrect
        if (checkFail == None):
            # success, so need to sleep before we carry on and get another webpage
            time.sleep(1)
        else:
            # failure, cancel the scrape
            print("Not a valid URL or ASIN")
            return
        #asin will be validated on the form
        #maybe put this in a try, something like that author problem may come up again
        #os.system("python C:/Users/Dave/PycharmProjects/test/addBookDemo.py")
        addBook(asin)
        print("Book successfully added to database")


    #now we can do the top 100 scrape.
    #first need to find the ASIN in the top 100, so look for it in the 5 pages that make up the top 100
    #can probably put this in a loop, replacing the number with string manipulation
    found = None
    location = 0
    locationOnPage = 0
    for x in range(1, 6):
        print("checking page "+ str(x))
        currentURL = "C:\demonstration\page" + str(x) + ".html"
        #currentURL = 'https://www.amazon.co.uk/Best-Sellers-Kindle-Store/zgbs/digital-text/ref=zg_bs_pg_' + str(x) + '?_encoding=UTF8&pg=' + str(x)
        #response = requests.get(currentURL, headers={'User-agent': 'Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36'})
        soup = BeautifulSoup(open(currentURL), 'html.parser')
        time.sleep(1)
        # set the results of the scan to soup
        #soup = BeautifulSoup(response.content, 'html.parser')
        #attempt to find the ASIN in the top 100
        currentItems = soup.findAll('div', {'class': 'a-section a-spacing-none p13n-asin'})
        loopCount = 0
        for i in currentItems:
            if loopCount < 20:
                #loopCount is used to go through the 20 books on each page
                currentText = str(i)
                index = int(currentText.find("asin\":\""))
                newASIN = currentText[index + 7:index + 17]
                if newASIN == asin:
                    #asin has been found, we can now scrape a result
                    found = 1
                    location = loopCount + 1
                    locationOnPage = loopCount
                    break
                else:
                    loopCount = loopCount + 1
        #exit for loop if found
        if (found):
            break
    if (found):
        #found is set, the book was found
        print("Book found at position " + str(((x-1)*20)+location))
        print("Book found in top 100, creating result...")
        specificBook = specificBookResultsClass()

        #we also already have soup set to the correct page
        #set the book rank
        specificBook.bookRank = location
        #set the book asin
        specificBook.bookASIN = asin
        #set the date/time
        currentDateTime = datetime.datetime.now()
        specificBook.bookDateOfScan = currentDateTime.strftime("%Y-%m-%d")
        specificBook.bookTimeOfScan = currentDateTime.strftime("%H-%M-%S")
        specificBook.bookTimeOfScan = specificBook.bookTimeOfScan.replace("-", ":")
        #reduce location by 1, we increased it before to make it the rank of the book
        location = location - 1

        #review score and number of reviews
        #code is better commented in the doScrape subroutine
        currentItems = soup.findAll('div', {'class': 'zg_itemImmersion'})
        listOfSkips = []
        x = 0
        #create a list of indexes where there are no review scores
        for i in currentItems:
            test = i.find('div', {'class': 'a-icon-row a-spacing-none'})
            if test == None:
                listOfSkips.append(x)
            x += 1
        #now find the span containing the review scores
        currentItems = soup.findAll('span', {'class': 'a-icon-alt'})
        #check if the current location is in the list, and therefore has no reviews
        if not locationOnPage in listOfSkips:
            currentValue = currentItems[locationOnPage]
            currentValue = currentValue.string
            currentValue = currentValue.strip()
            # we have a result in the format '3.9 out of 5 stars' when we need a decimal '3.9' to insert into the database
            currentValue = float(currentValue[:3])
            specificBook.bookReviewScore = currentValue

        # now the number of reviews
        currentItems = soup.findAll('a', {'class': 'a-size-small a-link-normal'})
        if not locationOnPage in listOfSkips:
            #has review scores
            currentValue = currentItems[locationOnPage]
            currentValue = currentValue.string
            currentValue = currentValue.strip()
            # currentValue could contain a comma if there are 1000 results or more- get rid of it
            currentValue = currentValue.replace(',', '')
            specificBook.bookNumOfReviews = currentValue
        #find and set the price of the book
        currentItems = soup.findAll('span', {'class': 'p13n-sc-price'})
        currentString = currentItems[location].string
        currentString = currentString.strip()
        # bookPrice is now in the format 'A£1.23'
        # bookPrice is actually a decimal value, so we need to get rid of the pound sign
        currentString = float(currentString[2:])
        specificBook.bookPrice = currentString
        #connect to the database
        db = MySQLdb.connect(host='localhost', user='root', passwd='password', db='webscrape3')
        c = db.cursor()
        # set to utf8 for foreign names and whatnot
        db.set_character_set('utf8')
        c.execute('SET NAMES utf8;')
        c.execute('SET CHARACTER SET utf8;')
        c.execute('SET character_set_connection=utf8;')
        # note that ignore has been used again here to ignore when there is no NumOfReviews or ReviewScore
        # change this to some better error handling later
        query = """INSERT IGNORE INTO results (BookASIN, Rank, ReviewScore, NumOfReviews, BookPrice, DateOfScan, TimeOfScan) VALUES (%s,%s,%s,%s,%s,%s,%s)"""
        c.execute(query, (
            specificBook.bookASIN, specificBook.bookRank, specificBook.bookReviewScore,
            specificBook.bookNumOfReviews, specificBook.bookPrice, specificBook.bookDateOfScan,
            specificBook.bookTimeOfScan))
        db.commit()
        # close the database
        db.close()
        print("Result Created.")
    else:
        print("Book was not found in the top 100.")

#takes an ASIN as input
#specificBookTop100Scrape("B0080GQYHE")
specificBookTop100Scrape(sys.argv[1])