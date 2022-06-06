CREATE TABLE [dbo].[Locations] (
    [Id]           NVARCHAR (450) NOT NULL,
    [Street]       NVARCHAR (MAX) NULL,
    [RestaurantId] NVARCHAR (450) NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Locations_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [dbo].[Restaurants] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Locations_RestaurantId]
    ON [dbo].[Locations]([RestaurantId] ASC) WHERE ([RestaurantId] IS NOT NULL);

