# nginx作为前端Web服务器
FROM nginx

# 维护者信息
MAINTAINER albertzhaoz

# 复制文件夹到容器目录下
COPY . /usr/share/nginx/html/
COPY default.conf /etc/nginx/conf.d/default.conf

# EXPOSE 9990