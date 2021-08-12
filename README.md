# HLessCMS

Headless CMS


## Solution design:

- MSSql Database
    - Tables storing objects in JSON
- Redis cache with cache management from Admin UI to expire cache
- User created "schemas" stored as json in MSSQL with typeId for indexing
- Schemas are stored in published and draft states allowing changes to be made and tested before publishing new versions.
- Datbase will be managed with MSSql project instead of entity framework
- Micro ORM Dapper will be used for DB operations
