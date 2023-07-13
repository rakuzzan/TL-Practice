SELECT *
FROM Sportsman;

SELECT *
FROM Sportsman
WHERE FirstName = 'Андрей';

SELECT *
FROM Performance
WHERE Value > 2;

SELECT *
FROM Coach
WHERE FirstName = 'Мария' AND BirthDate >= '1980-01-01';

SELECT *
FROM Coach
WHERE FirstName = 'Мария' OR BirthDate = '1980-01-01';

SELECT * 
FROM SportType
WHERE UnitOfMeasurment != 'м'

SELECT * 
FROM Competition
	WHERE Date BETWEEN '2023-08-05' AND '2023-10-20'

SELECT * 
FROM Competition
	WHERE Date NOT BETWEEN '2023-09-05' AND '2023-10-20'

SELECT TOP 5 *
FROM Performance
ORDER BY Value DESC

SELECT TOP 3 * 
FROM Coach
ORDER BY BirthDate ASC

SELECT Coach.FirstName, Coach.LastName, COUNT(Sportsman.SportsmanId) AS TotalSportsmen
FROM Coach
INNER JOIN Sportsman ON Coach.CoachId = Sportsman.CoachId
GROUP BY Coach.FirstName, Coach.LastName;

SELECT Coach.FirstName, Coach.LastName, COUNT(Sportsman.SportsmanId) AS TotalSportsmen
FROM Coach
INNER JOIN Sportsman ON Coach.CoachId = Sportsman.CoachId
GROUP BY Coach.FirstName, Coach.LastName
HAVING COUNT(Sportsman.SportsmanId) >= 3;