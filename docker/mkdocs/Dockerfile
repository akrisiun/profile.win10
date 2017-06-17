FROM gliderlabs/alpine:3.2

MAINTAINER AndriusK <akrisiun@gmail.com>
# https://github.com/jobandtalent/docker-mkdocs/blob/master/Dockerfile
# docker build --build-arg http_proxy=http://???:3128/ .

ENV no_proxy 127.0.0.1 
ENV http_proxy ${http_proxy}
ENV https_proxy ${http_proxy}

RUN apk add --update curl mc python3 py-pip
RUN pip install --upgrade pip && pip3 install mkdocs && rm -rf /var/cache/apk/*

WORKDIR /docs
VOLUME /docs
ADD run.sh /run.sh
RUN chmod +x /run.sh
# ENV PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin

EXPOSE 8000

ENTRYPOINT ["/bin/sh", "-c", "mkdocs serve --dev-addr=0.0.0.0:8000"]
# ENTRYPOINT ["mkdocs"]

CMD "/run.sh"
