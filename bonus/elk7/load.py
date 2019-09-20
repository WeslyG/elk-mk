import uuid
import random
import lorem
import namegenerator
import threading
from random import randrange
from datetime import timedelta, datetime, timezone
from elasticsearch import Elasticsearch

es = Elasticsearch(["10.33.51.24"], maxsize=25)

# s = lorem.sentence()
# s = lorem.paragraph()
s = lorem.text()

type = ['hight', 'low', 'top', 'ever', 'center', 'right', 'left']
d1 = datetime.strptime('1/1/2000 1:30 PM', '%m/%d/%Y %I:%M %p')
d2 = datetime.strptime('1/1/2020 4:50 AM', '%m/%d/%Y %I:%M %p')

def generateDoc():
  return {
      "timestamp": datetime.now(),
      "message": lorem.text(),
      "userID": str(uuid.uuid4()),
      "Name": namegenerator.gen(),
      "type": random.choice(type),
      "time1": random_date(d1, d2).isoformat(),
      "time2": random_date(d1, d2).isoformat(),
      "time3": random_date(d1, d2).isoformat()
  }

def random_date(start, end):
    """
    This function will return a random datetime between two datetime 
    objects.
    """
    delta = end - start
    int_delta = (delta.days * 24 * 60 * 60) + delta.seconds
    random_second = randrange(int_delta)
    return start + timedelta(seconds=random_second)


def writeDocInEs(docs):
  return es.index(index='load-test', doc_type='doc', body=docs)


def loadRun(count):
  for i in range(count):
    a = writeDocInEs(generateDoc())
    # print(a)
    print('Write %s' % i)


# if __name__ == '__main__':
#     for i in range(5):
#         my_thread = threading.Thread(target=writeDocInEs, args=(generateDoc(),))
#         my_thread.start()


loadRun(10000)

