
```
docker run -it -d -p 0.0.0.0:9009:9000 -v /var/run/docker.sock:/var/run/docker.sock --name port1 portainer/portainer 

that you have started Portainer container with the following Docker flag -v /var/run/docker.sock:/var/run/docker.sock

docker swarm init
docker swarm join     --token SWMTKN-1-2ixd1q0oj5c59799na3xkpl8qifxryfzhtzfoaje99gmoxlq3b-5yfai63q6s1cgi921ddlqijc7     192.168.65.2:2377

docker service create \
--name portainer --publish 9009:9000 \
--constraint 'node.role == manager' --mount type=bind,src=//var/run/docker.sock,dst=/var/run/docker.sock portainer/portainer -H unix:///var/run/docker.sock

docker run -it -d -p 0.0.0.0:9009:9000 -v /var/run/docker.sock:/var/run/docker.sock --name port1 portainer/portainer 

docker service ps
docker ps
docker logs port1

```