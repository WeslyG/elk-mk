## SerilogStructure

1. Найти все 500 статусы ответа, отсортировать по возрастанию времени запроса - визуализировать

fields.StatusCode: [500 TO 560 ]

2. Найти все записи с временем ответа от 10 до 200 мс с level Information и статус код не 200

fields.time: [10 TO 200 ] AND level: information NOT fields.StatusCode: 200

3. Найти все статус коды 201 и вывести самые долгие из них.

fields.StatusCode: 201

4. Найти все сообщения с текстом «Server»

....
