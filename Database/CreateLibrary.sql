IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220934_InitialLibrary'
)
BEGIN
    CREATE TABLE [Author] (
        [ID] int NOT NULL IDENTITY,
        [FirstName] nvarchar(80) NOT NULL,
        [LastName] nvarchar(80) NOT NULL,
        CONSTRAINT [PK_Author] PRIMARY KEY ([ID])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220934_InitialLibrary'
)
BEGIN
    CREATE TABLE [Publisher] (
        [ID] int NOT NULL IDENTITY,
        [PublisherName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Publisher] PRIMARY KEY ([ID])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220934_InitialLibrary'
)
BEGIN
    CREATE TABLE [Book] (
        [ID] int NOT NULL IDENTITY,
        [Title] nvarchar(200) NOT NULL,
        [Price] decimal(6,2) NOT NULL,
        [PublishingDate] datetime2 NOT NULL,
        [AuthorID] int NULL,
        [PublisherID] int NULL,
        CONSTRAINT [PK_Book] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Book_Author_AuthorID] FOREIGN KEY ([AuthorID]) REFERENCES [Author] ([ID]) ON DELETE SET NULL,
        CONSTRAINT [FK_Book_Publisher_PublisherID] FOREIGN KEY ([PublisherID]) REFERENCES [Publisher] ([ID]) ON DELETE SET NULL
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220934_InitialLibrary'
)
BEGIN
    CREATE INDEX [IX_Book_AuthorID] ON [Book] ([AuthorID]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220934_InitialLibrary'
)
BEGIN
    CREATE INDEX [IX_Book_PublisherID] ON [Book] ([PublisherID]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220934_InitialLibrary'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261102220934_InitialLibrary', N'10.0.14');
END;

COMMIT;
GO

