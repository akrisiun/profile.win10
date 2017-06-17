FROM php:apache

RUN docker-php-ext-install mysqli mbstring

# zend_extension=/usr/local/lib/php/extensions/no-debug-non-zts-20131226/xdebug.so
# docker build --build-arg http_proxy=http://???:3128/  --build-arg https_proxy=http://???:5865 .


ENV no_proxy 127.0.0.1;192.168.*.*;172.*.*.* 
ENV http_proxy ${http_proxy}
ENV https_proxy ${https_proxy}

# curl https://pecl.php.net/
# RUN pecl install xdebug
# RUN echo 'zend_extension = /usr/local/lib/php/extensions/no-debug-non-zts-20131226/xdebug.so' >> /usr/local/etc/php/php.ini
# RUN touch /usr/local/etc/php/conf.d/xdebug.ini; \
#    echo xdebug.remote_enable=1 >> /usr/local/etc/php/conf.d/xdebug.ini; \
#    echo xdebug.remote_autostart=0 >> /usr/local/etc/php/conf.d/xdebug.ini; \
#    echo xdebug.remote_connect_back=1 >> /usr/local/etc/php/conf.d/xdebug.ini; \
#    echo xdebug.remote_port=9000 >> /usr/local/etc/php/conf.d/xdebug.ini; \
#    echo xdebug.remote_log=/tmp/php5-xdebug.log >> /usr/local/etc/php/conf.d/xdebug.ini;

RUN echo 'date.timezone = Europe/Vilnus' > /usr/local/etc/php/conf.d/date.ini

# docker run --rm -ti  --name web -p 127.0.0.1:8080:80 -v /path/to/projects:/var/www/html --link db:db  phpmysqli
# After this phpinfo respectively php -i shows that xdebug 2.3.2 is up and running.