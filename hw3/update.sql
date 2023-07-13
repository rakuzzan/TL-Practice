UPDATE [Coach]
SET FirstName = 'Федор'
WHERE CoachId = 1;

UPDATE [Sportsman]
SET LastName = 'Громов'
WHERE LastName LIKE 'Иван%';

UPDATE [Competition]
SET Venue = 'Россия, Сочи, Олимпийский стадион «Фишт»'
WHERE Date BETWEEN '2023-08-01' AND '2023-08-31';

UPDATE [SportType]
SET Title = 'Плавание 100 метров'
WHERE Title IN ('Бег на 100 метров', 'Прыжки в высоту');

UPDATE [Performance]
SET Value = 11.2
WHERE SportsmanId = 1 AND CompetitionId = 1 AND SportTypeId = 1;