# Ip Manager

It's a demonstration purpose app

## Implements 

```c#

Clean Architecture

dotnet --version
6.0.301

HttpClient used for another apis comsumption

DI

FluentValidation

Unit Test

for integration test was used postman tool, and the postman file are added to the folder solution

IMemoryCache
IDistributedCache
# for use Redis IDistributedCache uncomment commented lines in get and set method at CacheService
# configure redis server url

EF - Entity Framework implemented with repository pattern 
#for test purpouse is used a sqlite ddbb 
#in production use a distributed ddbb

Docker - for deploy build a docker image:
docker build -t ipmanager .
docker run -d -p 8080:80 --name meli_app ipmanager

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)