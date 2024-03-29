SELECT SUM([Difference]) AS [SumDifference]
FROM 
    (
      SELECT wd1.[FirstName] AS [Host Wizard]
           , wd1.[DepositAmount] AS [Host Wizard Deposit]
      	   , wd2.[FirstName] AS [Guest Wizard]
           , wd2.[DepositAmount] AS [Guest Wizard Deposit]
      	   , wd1.[DepositAmount] - wd2.[DepositAmount] AS [Difference]
            FROM [WizzardDeposits] AS wd1
      INNER JOIN [WizzardDeposits] AS wd2
          ON wd1.[Id] + 1 = wd2.[Id] 
    ) AS [DifferenceSubQuery]