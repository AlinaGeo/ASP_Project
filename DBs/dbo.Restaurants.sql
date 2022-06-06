CREATE TABLE [dbo].[Restaurants] (
    [Id]   NVARCHAR (450) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED ([Id] ASC)
);

