Use [ToyStore]
Go

SELECT m.Name, Count(*)
FROM Manufacturers m
JOIN Toys t
ON m.Id = t.ManufacturerId
JOIN AgeRanges a
ON a.Id = t.AgeRangesId
WHERE a.MinimumAge >= 5 AND a.MaximumAge <= 10
GROUP BY m.Name
ORDER BY m.Name

SELECT m.Name, (SELECT Count(*)
FROM Toys t
INNER JOIN AgeRanges a
ON t.AgeRangesId = a.Id
WHERE a.MinimumAge >= 5 AND a.MaximumAge <= 10 AND m.Id = t.ManufacturerId)
FROM Manufacturers m
ORDER BY m.Name