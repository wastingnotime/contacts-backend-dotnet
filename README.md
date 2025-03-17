# contacts-backend-dotnet

**contacts-backend-dotnet** is part of "contacts" project that is an initiative where we try to explore frontend and backend implementations in order to better understand it cutting-edge features. This repository presents a dotnet rest API sample.

## stack
* dotnet 9.0
* webapi
* sqlite
* entity framework

## features
* migrations



## get started (linux instructions only)

### option 1 - use latest docker image from dockerhub

execute the remote docker image
```
docker run -p 8010:8080 wastingnotime/contacts-backend-dotnet:0.1.0-alpha
```

### option 2 - build and run a local docker image
build a local docker image
```
docker build --tag contacts-backend-dotnet .
```

execute the local docker image
```
docker run -p 8010:8080 contacts-backend-dotnet
```

### option 3 - execute from source code

- install dotnet 9 [how to](https://learn.microsoft.com/en-us/dotnet/core/install/linux)
- go to root of solution and execute the commands below

set environment for development
```
cp .env_example .env
```

update deps
```
dotnet restore
```

install migration tool (only once)
```
dotnet tool install --global dotnet-ef
```

run migrations
```
dotnet ef database update
```

and then run the application
```
dotnet run 
```

## testing
create a new contact
```
curl --request POST \
  --url http://localhost:8010/contacts \
  --header 'Content-Type: application/json' \
  --data '{
	"firstName": "Albert",
	"lastName": "Einstein",
	"phoneNumber": "2222-1111"
  }'
```

retrieve existing contacts
```
curl --request GET \
  --url http://localhost:8010/contacts
```
more examples and details about requests on [verify.rest](https://raw.githubusercontent.com/wastingnotime/contacts-backend-dotnet/refs/heads/main/verify.rest)
