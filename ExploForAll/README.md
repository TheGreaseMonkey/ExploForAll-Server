# ExploForALl questionnaire game server

## How to perform EFCore migration

Step one, add a new migration using the CLI with the following command.

```
> Add-Migration [NAME]
```

After this a new migration should appear in the migration folder. Always check this to make sure EFCore does not do any weird stuff.

Next, it is time to update the database, again, using the CLI

```
> Update-database
```

That should be it.
