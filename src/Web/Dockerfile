FROM node:20-bookworm-slim

WORKDIR /src

COPY package.json .
COPY package-lock.json .

RUN npm ci

COPY . .

CMD ["npm", "run", "dev"]
