# ContactsBackendDotnet

There's two major decisions that I made in this version.

1. Database choice: Instead using an embedded database as SQLite that make more sense for tests purposes, I decided for mssql to stay closer from some companies scenarios thats guide developers to use a dev database server or localdb.


2. Architectural style: Instead of using DDD's patterns as Repository, I just exposed the dbcontext. For a microservice's world, it's acceptable once the unit is the service and the service is not complex. In other words, just change dbcontext to an inmemory for unit tests.
https://dotnetthoughts.net/how-to-mock-dbcontext-for-unit-testing/



## development database
in order to get the database running.... just do it:

```
chmod +x run.sh
./run.sh
```
Obs.: you should have docker installed and running on your machine.
