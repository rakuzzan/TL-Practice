SELECT Sportsman.FirstName, Sportsman.LastName, Performance.Value, SportType.Title, SportType.UnitOfMeasurment
FROM Sportsman
INNER JOIN Performance ON Sportsman.SportsmanId = Performance.SportsmanId
INNER JOIN SportType ON Performance.SportTypeId = SportType.SportTypeId;

SELECT Coach.FirstName AS "��� �������", Coach.LastName AS "������� �������",  Sportsman.FirstName AS "��� ����������", Sportsman.LastName AS "������� ����������"
FROM Coach
LEFT JOIN Sportsman ON Coach.CoachId = Sportsman.CoachId;

SELECT Competition.Title, Competition.Venue, Performance.Value, SportType.Title, SportType.UnitOfMeasurment
FROM Competition
RIGHT JOIN Performance ON Competition.CompetitionId = Performance.CompetitionId
INNER JOIN SportType ON Performance.SportTypeId = SportType.SportTypeId;
