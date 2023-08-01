USE SportCompetition;

-- Coach <===
INSERT INTO [Coach] (FirstName, LastName, BirthDate)
VALUES ('Иван', 'Иванов', '1980-01-01')

INSERT INTO [Coach] (FirstName, LastName, BirthDate)
VALUES ('Мария', 'Петрова', '1990-05-15')

INSERT INTO [Coach] (FirstName, LastName, BirthDate)
VALUES ('Алексей', 'Сидоров', '1975-11-30')

-- Sportsman <===
INSERT INTO [Sportsman] (FirstName, LastName, CoachId)
VALUES ('Андрей', 'Смирнов', 1)
INSERT INTO [Sportsman] (FirstName, LastName, CoachId)
VALUES ('Елена', 'Иванова', 2)
INSERT INTO [Sportsman] (FirstName, LastName, CoachId)
VALUES ('Дмитрий', 'Петров', 3)

-- Competition <===
INSERT INTO [Competition] (Date, Title, Venue)
VALUES ('2023-08-05', 'Чемпионат России по легкой атлетике', 'Москва, стадион "Лужники"')

INSERT INTO [Competition] (Date, Title, Venue)
VALUES ('2023-09-10', 'Кубок Европы по плаванию', 'Барселона, бассейн "Палав де лос Депортес"')

INSERT INTO [Competition] (Date, Title, Venue)
VALUES ('2023-10-20', 'Чемпионат мира по фигурному катанию', 'Токио, ледовый дворец "Хамарикю"')

-- SportType <===

INSERT INTO [SportType] (Title, UnitOfMeasurment)
VALUES ('Бег на 100 метров', 'сек')
INSERT INTO [SportType] (Title, UnitOfMeasurment)
VALUES ('Прыжки в высоту', 'м')
INSERT INTO [SportType] (Title, UnitOfMeasurment)
VALUES ('Плавание на 200 метров вольным стилем', 'мин')

-- Performance <===

INSERT INTO [Performance] (Value, SportsmanId, CompetitionId, SportTypeId)
VALUES (10.5, 1, 1, 1)

INSERT INTO [Performance] (Value, SportsmanId, CompetitionId, SportTypeId)
VALUES (1.95, 2, 2, 2)

INSERT INTO [Performance] (Value, SportsmanId, CompetitionId, SportTypeId)
VALUES (3.5, 3, 3, 3)