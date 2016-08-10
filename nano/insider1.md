https://hub.docker.com/r/stefanscherer/hello-dresden/
https://github.com/plossys/nodetraining/tree/master/06-express
https://github.com/StefanScherer/dockerfiles-windows/tree/master/node
Docker: https://github.com/phusion/baseimage-docker#running_startup_scripts


Windows 10 Insider 14325
Running this in a Hyper-V container is very similar:

FROM stefanscherer/node-windows:4-nano-onbuild
Changed some code to print "Hello Docker Meetup Dresden" and created the Docker Image with

docker build --isolation=hyperv -t express .
Then tagged and pushed to the Docker Hub

docker tag express:latest stefanscherer/hello-dresden:nano
docker push stefanscherer/hello-dresden:nano
You can run this Container with this command

docker run --isolation=hyperv -p 8080:3000 -d --name=express stefanscherer/hello-dresden:nano
To open the web page you must use the container's IP address as you can't connect from your container host to the container right now. Otherwise use the IP address of your container host if you want to connect from outside of your container host.

start http://$(docker inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' ex
