# Как поставить докер на windows ?

Идем на оф "магазин" и скачиваем, но они там все хитрые, требуют регистрации, поэтому если вы не пользуетесь CHOCO то придется регаться


```
https://store.docker.com/editions/community/docker-ce-desktop-windows
```

Не все так просто, докер под windows доступен только начиная с windows 10 1709 так как для его поддержки microsoft пришлось не плохо так заморочится и переписать у себя пару вещей. 

Кроме этого, в настройках биоса должна быть включена виртуализация hyper-v

И в самой системе есть дефолтный виртуализатор (не совместимый с другими!) который называется hyper-v который так же нужно включить. 

Однако докер после установки сам предложит это сделать, и вам нужно только согласиться.


### Дополнительные утилиты

Кроме самого докера поставится еще много инструментов для работы с ним 

* swarm 
* docker machine 
* compose 
* kubernetes

И это хорошо, поскольку если у вас linux каждую утилиту нужно ставить дополнительно.

Нам нужна будет утилита docker-compose которая идет в комплекте. 

После установки и запуска, заходим в папку docker нажимаем Правую кнопку мышки с зажатым SHIFT > открыть окно Power Shell здесь

Запускаем командой 

```
docker-compose up -d 
```

Docker скачает и запустит kibana + elasticsearch на портах 9200 и 5601 соотвественно