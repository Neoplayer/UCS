# pull official base image
FROM node:16.14.2-alpine

# set working directory
WORKDIR /app

# # add `/app/node_modules/.bin` to $PATH
# ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./
COPY package-lock.json ./

# RUN npm cache clean --force
RUN npm cache clean --force


RUN npm install
# RUN npm install react-scripts@5.0.0 -g

# add app
COPY / ./

# start app
ENTRYPOINT  ["npm", "start"]