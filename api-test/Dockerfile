FROM postman/newman:alpine
COPY *.json /etc/newman
WORKDIR /etc/newman
CMD ["run", "api.postman_collection.json", "-r", "cli,junit"]