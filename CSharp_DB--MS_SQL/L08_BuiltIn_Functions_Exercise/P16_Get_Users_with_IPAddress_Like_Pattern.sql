  SELECT [UserName], [IpAddress] AS [IP Address]
    FROM [Users]
   WHERE [IpAddress] LIKE '[1-9][0-9][0-9].1[0-9]%.[1-9]%.[1-9][0-9][0-9]'
ORDER BY [Username] ASC
