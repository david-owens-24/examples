from bs4 import BeautifulSoup
import requests
import time
import sys

import datetime
import MySQLdb

def deleteBook(input):
    #open database and delete book
    db = MySQLdb.connect(host='localhost', user='root', passwd='password', db='webscrape3')
    c = db.cursor()
    # set to utf8 for foreign names and whatnot
    db.set_character_set('utf8')
    c.execute('SET NAMES utf8;')
    c.execute('SET CHARACTER SET utf8;')
    c.execute('SET character_set_connection=utf8;')
    # IMPORTANT HERE
    # if book already exists then this will not create a new record. User can choose to update the booklength and anything else added in the future
    query = """DELETE FROM books WHERE ASIN = %s"""
    try:
        c.execute(query, (input,))
        db.commit()
        print("Book successfully deleted")
    except MySQLdb.IntegrityError as e:
        print(e)
    db.close()
    
#takes an ASIN as input
#addBook("B07BTQFF45", 1)
deleteBook(sys.argv[1])
#deleteBook("B074FYCSYQ")