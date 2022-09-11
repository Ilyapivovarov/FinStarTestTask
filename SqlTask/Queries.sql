-- 2.1 

SELECT ClientName, Count(ClientId) ContactCount
FROM Clients s 
LEFT JOIN ClientContacts cc ON s.Id = cc.ClientId
GROUP BY ClientName

-- 2.2
SELECT ClientName, Count(ClientId) ContactCount
FROM Clients s 
LEFT JOIN ClientContacts cc ON s.Id = cc.ClientId
GROUP BY ClientName
HAVING Count(ClientId) > 2

-- 3
SELECT t.Id, (SELECT TOP 1 tt.Dt FROM ThridTask tt WHERE t.Dt = tt.Dt AND t.Id = tt.Id) AS Sdt, (SELECT TOP 1 tt.Dt FROM ThridTask tt WHERE t.Dt < tt.Dt AND t.Id = tt.Id ORDER BY tt.Dt) AS Edt
FROM ThridTask t

WHERE (SELECT TOP 1 tt.Dt FROM ThridTask tt WHERE t.Dt < tt.Dt AND t.Id = tt.Id ORDER BY tt.Dt) IS NOT NULL