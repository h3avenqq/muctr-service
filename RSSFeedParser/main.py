import mysql.connector
from parser import parse_events, parse_news

NEWS_URL = 'https://www.muctr.ru/bitrix/rss.php?ID=10&TYPE=news&LIMIT=20'
EVENTS_URL = 'https://www.muctr.ru/bitrix/rss.php?ID=19&TYPE=notifies&LIMIT=10'


def insert_info_into_database():
    try:
        with mysql.connector.connect(host='host',
                                     database='host',
                                     user='user',
                                     password='password') as connection:
            with connection.cursor() as cursor:
                news_insert_query = """INSERT INTO News (Title, Description, PublicationDate, MediaUrl) 
                VALUES (%s, %s, %s, %s)"""
                events_insert_query = """INSERT INTO Events (Title, Description, PublicationDate, MediaUrl) 
                VALUES (%s, %s, %s, %s)"""
                cursor.executemany(news_insert_query, parse_news(NEWS_URL))
                connection.commit()
                cursor.executemany(events_insert_query, parse_events(EVENTS_URL))
                connection.commit()


    except mysql.connector.Error as error:
        print(error)


if __name__ == '__main__':
    insert_info_into_database()
