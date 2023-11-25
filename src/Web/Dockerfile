FROM node:lts-slim

WORKDIR /src

COPY package.json .
COPY package-lock.json .

RUN npm ci

COPY . .

CMD ["npm", "run", "dev", "--", "--host"]
