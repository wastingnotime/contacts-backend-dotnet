# ContactsBackendDotnet

## about

## decisions
There's two major decisions that I made in this version.

1. Database choice: Using an embedded database as SQLite that can be found on /data volume and it is created on build using migrations.

2. Architectural style: Instead of using DDD's patterns as Repository, I just exposed the dbcontext. For a microservice's world, it's acceptable once the unit is the service and the service is not complex. In other words,I just changed dbcontext to use inmemory SQLite for unit tests.

## stack

## local build instructions

## development instructions
