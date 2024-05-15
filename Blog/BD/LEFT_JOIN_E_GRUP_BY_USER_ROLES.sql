SELECT
    [User].[Id],
    [User].[Name],
    [User].[Email],
    STRING_AGG([Role].Name, ', ') AS Roles
FROM
    [User]
    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
GROUP BY
    [User].[Id],
    [User].[Name],
    [User].[Email]
ORDER BY
    [User].[Id];
   