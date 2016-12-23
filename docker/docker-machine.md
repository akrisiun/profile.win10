### Adding a host without a driver
You can add a host to Docker which only has a URL and no driver. Then you can use the machine name you provide here for an existing host so you don’t have to type out the URL every time you run a Docker command.

``
$ docker-machine create --driver none --url=tcp://50.134.234.20:2376 custombox
$ docker-machine ls
NAME        ACTIVE   DRIVER    STATE     URL
custombox   *        none      Running   tcp://50.134.234.20:2376
```