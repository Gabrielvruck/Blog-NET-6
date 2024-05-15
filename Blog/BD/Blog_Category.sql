CREATE TABLE [Category] (
[Id] int not null IDENTITY(1,1),
[Name] NVARCHAR(80) NOT NULL,
[Slug] VARCHAR(80) NOT NULL,

CONSTRAINT [PK_Category] PRIMARY KEY([Id]),
CONSTRAINT [UQ_Category_Slug] UNIQUE([Slug])

)

CREATE NONCLUSTERED INDEX [IX_Category_Slug] ON [Category]([Slug])