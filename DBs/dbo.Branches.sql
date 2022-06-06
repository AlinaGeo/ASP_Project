CREATE TABLE [dbo].[Branches] (
    [Id]           NVARCHAR (450) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [RestaurantId] NVARCHAR (450) NULL,
    CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Branches_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [dbo].[Restaurants] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Branches_RestaurantId]
    ON [dbo].[Branches]([RestaurantId] ASC);

