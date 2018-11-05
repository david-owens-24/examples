from bs4 import BeautifulSoup
import requests
import time

import datetime
import MySQLdb

class resultsClass:
    # class to store the results of scans
    # note does not include book length or synopsis
    bookTitle = ""
    bookASIN = ""
    bookAuthor = ""
    bookURL = ""
    bookPrice = ""
    bookRank = ""
    bookReviewScore = ""
    bookNumOfReviews = ""
    bookDateOfScan = ""
    bookTimeOfScan = ""

def doScrape(url, pageNum, finalList, dateTime):
    # https://www.amazon.co.uk/Best-Sellers-Kindle-Store/zgbs/digital-text/ref=zg_bs_pg_2?_encoding=UTF8&pg=2 change the numbers
    #url = str
    #response = requests.get(url, headers={'User-agent': 'Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36'})

    # set the results of the scan to soup
    #page = open(url)
    soup = BeautifulSoup(open(url),'html.parser')
    #soup = BeautifulSoup(open(url), 'html.parser')

    # create the results array.
    resultsList = [resultsClass() for i in range(0,20)]

    # first set the rankings and the date/time as these are not scraped
    offset = pageNum * 20
    for x in range(0,20):
        resultsList[x].bookRank = x+1+offset
        resultsList[x].bookDateOfScan = dateTime.strftime("%Y-%m-%d")
        resultsList[x].bookTimeOfScan = dateTime.strftime("%H-%M-%S")
        resultsList[x].bookTimeOfScan = resultsList[x].bookTimeOfScan.replace("-",":")

    # title, asin, author, url, rank, score, number of reviews
    # title first
    currentItems = soup.find_all('div', {'class': 'p13n-sc-truncate p13n-sc-line-clamp-1'})
    x = 0
    for i in currentItems:
        # we only actually want 0 to 19
        if x < 20:
            i = i.string
            i = i.strip()
            resultsList[x].bookTitle = i
            x = x + 1
        else:
            break

    # now the asin
    currentItems = soup.findAll('div', {'class': 'a-section a-spacing-none p13n-asin'})
    x = 0
    for i in currentItems:
        if x < 20:
            currentText = str(i)
            index = int(currentText.find("asin\":\""))
            newASIN = currentText[index+7:index+17]
            resultsList[x].bookASIN = newASIN
            x = x + 1
        else:
            break

    # now the author
    currentItems = soup.findAll('div', {'class': 'a-row a-size-small'})
    x = 0
    y = 0
    for i in currentItems:
        # this one is weird we need to skip an index each time we successfully scrape, amazon use the same class name for the author name
        # and the words 'kindle edition'
        # so we end up with 40 instances rather than the usual 20
        # fortunately it follows a pattern- even numbers contain the author name
        # and odd numbers contain kindle edition
        if x < 39:
            if x % 2 == 0:
                i = i.string
                i = i.strip()
                resultsList[y].bookAuthor = i
                y = y + 1
                x = x + 1
            else:
                x = x + 1
        else:
            break

    #now the price
    currentItems = soup.findAll('span', {'class': 'p13n-sc-price'})
    x = 0
    for i in currentItems:
        # we only actually want 0 to 19
        if x < 20:
            i = i.string
            i = i.strip()
            #bookPrice is now in the format '£1.23'
            #bookPrice is actually a decimal value, so we need to get rid of the pound sign
            #index changed to 2 for local scrape, should be 1
            i = float(i[2:])
            resultsList[x].bookPrice = i
            x = x + 1
        else:
            break

    #now the review score and the number of reviews
    #can be problematic as if there are no reviews then the html does not include "a-icon-row a-spacing-none"
    #as such we can't simply go through them 1 at a time as if there is one missing it will assign incorrect values to the next book in the list
    #to solve this we must try to find the location where it is missed
    #and then skip over this one

    #searching for 'a-icon-row a-spacing-none' will result in a maximum of 20. If we do not find 20 then an error could happen.
    #we will have to check zg_itemImmersion and see which one does not contain 'a-icon-row a-spacing-none' in order to skip it
    #simply look for the tag 'a-icon-row a-spacing-none' in each 'zg_itemImmersion'
    #and if it is not found record the number of the item that should be skipped

    currentItems = soup.findAll('div', {'class': 'zg_itemImmersion'})
    listOfSkips = []
    x = 0
    for i in currentItems:
        test = i.find('div', {'class': 'a-icon-row a-spacing-none'})
        #print("\n")
        if test == None:
            #print("not found at location ")
            listOfSkips.append(x)
        x +=1

    currentItems = soup.findAll('span', {'class': 'a-icon-alt'})
    loopCounter = 0
    x = 0
    while loopCounter < 20:
        #if we come to an iteration that we want to skip, we must remain on the same currentItems[x] but increment the loop counter as if it set something
        if loopCounter not in listOfSkips:
            currentValue = currentItems[x]
            currentValue = currentValue.string
            currentValue = currentValue.strip()
            # similarly to the price, we need to do a bit of string manipulation
            # we have a result in the format '3.9 out of 5 stars' when we need a decimal '3.9' to insert into the database
            currentValue = float(currentValue[:3])
            resultsList[loopCounter].bookReviewScore = currentValue
            x+=1
        loopCounter += 1



    #now the number of reviews
    currentItems = soup.findAll('a', {'class': 'a-size-small a-link-normal'})
    loopCounter = 0
    x = 0
    while loopCounter < 20:
        # if we come to an iteration that we want to skip, we must remain on the same currentItems[x] but increment the loop counter as if it set something
        if loopCounter not in listOfSkips:
            currentValue = currentItems[x]
            currentValue = currentValue.string
            currentValue = currentValue.strip()
            #currentValue could contain a comma if there are 1000 results or more- get rid of it
            currentValue = currentValue.replace(',', '')
            resultsList[loopCounter].bookNumOfReviews = currentValue
            x += 1
        loopCounter += 1

    #ok the url can be derived by attaching the ASIN to https://www.amazon.co.uk/dp/
    #e.g https://www.amazon.co.uk/dp/B019PIOJYU where the ASIN is B019PIOJYU
    #don't actually need to search the scrape again, since we have already actually got the ASIN for every item
    #make sure this next part goes after the ASIN scrape
    #could actually put this in the ASIN part so i dont forget it
    webpageString = "https://www.amazon.co.uk/dp/"
    for i in range(0,20):
        resultsList[i].bookURL = webpageString + resultsList[i].bookASIN
    # setting the final list to the new scraped things
    for x in range(0,20):
        #print(resultsList[x].bookASIN)
        finalList[x+offset] = resultsList[x]

    print(pageNum)
    print(" done")

def top100Scrape():
    #get current date/time for the scan initiation
    currentDateTime = datetime.datetime.now()
    finalResultsList = [resultsClass() for i in range(0,100)]
    currentURL = "C:\demonstration\page1.html"
    doScrape(currentURL, 0, finalResultsList, currentDateTime)
    time.sleep(1)
    currentURL = "C:\demonstration\page2.html"
    doScrape(currentURL, 1, finalResultsList, currentDateTime)
    time.sleep(1)
    currentURL = "C:\demonstration\page3.html"
    doScrape(currentURL, 2, finalResultsList, currentDateTime)
    time.sleep(1)
    currentURL = "C:\demonstration\page4.html"
    doScrape(currentURL, 3, finalResultsList, currentDateTime)
    time.sleep(1)
    currentURL = "C:\demonstration\page5.html"
    doScrape(currentURL, 4, finalResultsList, currentDateTime)
    print("done")

    #now add to database

    #this works
    db = MySQLdb.connect (host = 'localhost', user = 'root', passwd = 'password', db = 'webscrape3')
    c= db.cursor()
    #set to utf8 for foreign names and whatnot
    db.set_character_set('utf8')
    c.execute('SET NAMES utf8;')
    c.execute('SET CHARACTER SET utf8;')
    c.execute('SET character_set_connection=utf8;')
    #first create the new books to make sure that we dont mess up our ASIN foreign keys in the results table
    #IMPORTANT HERE
    #IGNORE in order to ignore the queries which would create a duplicate ASIN in books
    #also causes it to ignore all errors though, if errors start happening delete this IGNORE and check
    #query = """INSERT IGNORE INTO books (BookTitle, ASIN, BookAuthor, BookURL, BookPrice) VALUES (%s,%s,%s,%s,%s)"""
    query = """INSERT INTO books (BookTitle, ASIN, BookAuthor, BookURL) VALUES (%s,%s,%s,%s)"""
    for i in range(0,100):
        #c.execute(query, (finalResultsList[i].bookTitle, finalResultsList[i].bookASIN, finalResultsList[i].bookAuthor, finalResultsList[i].bookURL, finalResultsList[i].bookPrice))
        #db.commit()
        try:
            c.execute(query, (finalResultsList[i].bookTitle, finalResultsList[i].bookASIN, finalResultsList[i].bookAuthor, finalResultsList[i].bookURL,))
            db.commit()
        except MySQLdb.IntegrityError as e:
            print(e)
            if e.args[0] == 1062:
                # set new updates here
                print(i)
                #print("Updating already existing row with new values found")
                #c.execute("""UPDATE books SET ASIN=%s WHERE ASIN=%s """,
                          #(finalResultsList[i].bookASIN, finalResultsList[i].bookASIN))
                #db.commit()
    #now we create the results with the rest of the scraped stuff
    #note that ignore has been used again here to ignore when there is no NumOfReviews or ReviewScore
    #change this to some better error handling later
    query = """INSERT IGNORE INTO results (BookASIN, Rank, ReviewScore, NumOfReviews, BookPrice, DateOfScan, TimeOfScan) VALUES (%s,%s,%s,%s,%s,%s,%s)"""
    for i in range(0,100):
     c.execute(query, (finalResultsList[i].bookASIN, finalResultsList[i].bookRank, finalResultsList[i].bookReviewScore, finalResultsList[i].bookNumOfReviews, finalResultsList[i].bookPrice, finalResultsList[i].bookDateOfScan, finalResultsList[i].bookTimeOfScan))
     db.commit()

    #close the database
    db.close()
    print("done")

top100Scrape()