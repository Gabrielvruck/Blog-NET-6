-- CREATE TABLE [Role] (
-- [Id] int not null IDENTITY(1,1),
-- [Name] NVARCHAR(80) NOT NULL,
-- [Slug] VARCHAR(80) NOT NULL,

-- CONSTRAINT [PK_Role] PRIMARY KEY([Id]),
-- CONSTRAINT [UQ_Role_Slug] UNIQUE([Slug])

-- )

-- CREATE NONCLUSTERED INDEX [IX_Role_Slug] ON [Role]([Slug])

CREATE TABLE [UserRole](
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY([UserId],[RoleId])
)