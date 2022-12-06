from bs4 import BeautifulSoup
import requests

NEWS_URL = 'https://www.muctr.ru/bitrix/rss.php?ID=10&TYPE=news&LIMIT=20'
EVENTS_URL = 'https://www.muctr.ru/bitrix/rss.php?ID=19&TYPE=notifies&LIMIT=10'


def get_content_from_RSS(rss_url: str) -> BeautifulSoup:
    feed_data = requests.get(rss_url)
    return BeautifulSoup(feed_data.content, 'xml')


def parse_news(rss_url: str) -> list:
    soup = get_content_from_RSS(rss_url)
    items = soup.find_all('item')
    news = []

    for item in items:
        piece_of_news = parse_item(item)
        news.append(piece_of_news)

    return news


def parse_events(rss_url: str) -> list:
    soup = get_content_from_RSS(rss_url)
    items = soup.find_all('item')
    events = []

    for item in items:
        event = parse_item(item)
        events.append(event)

    return events


def parse_item(item: BeautifulSoup) -> dict:
    return {
            'title': item.title.text,
            'description': item.description.text,
            'media_url': item.enclosure['url'],
            'publication_date': item.pubDate.text,
        }

