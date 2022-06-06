CREATE TABLE [dbo].[Beverages] (
    [Id]           NVARCHAR (450) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [RestaurantId] NVARCHAR (450) NULL,
    CONSTRAINT [PK_Beverages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Beverages_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [dbo].[Restaurants] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Beverages_RestaurantId]
    ON [dbo].[Beverages]([RestaurantId] ASC);

