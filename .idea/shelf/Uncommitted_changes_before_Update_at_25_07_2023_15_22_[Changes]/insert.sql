USE SportCompetition;

-- Coach <===
INSERT INTO [Coach] (FirstName, LastName, BirthDate)
VALUES ('����', '������', '1980-01-01')

INSERT INTO [Coach] (FirstName, LastName, BirthDate)
VALUES ('�����', '�������', '1990-05-15')

INSERT INTO [Coach] (FirstName, LastName, BirthDate)
VALUES ('�������', '�������', '1975-11-30')

-- Sportsman <===
INSERT INTO [Sportsman] (FirstName, LastName, CoachId)
VALUES ('������', '�������', 1)
INSERT INTO [Sportsman] (FirstName, LastName, CoachId)
VALUES ('�����', '�������', 2)
INSERT INTO [Sportsman] (FirstName, LastName, CoachId)
VALUES ('�������', '������', 3)

-- Competition <===
INSERT INTO [Competition] (Date, Title, Venue)
VALUES ('2023-08-05', '��������� ������ �� ������ ��������', '������, ������� "�������"')

INSERT INTO [Competition] (Date, Title, Venue)
VALUES ('2023-09-10', '����� ������ �� ��������', '���������, ������� "����� �� ��� ��������"')

INSERT INTO [Competition] (Date, Title, Venue)
VALUES ('2023-10-20', '��������� ���� �� ��������� �������', '�����, ������� ������ "��������"')

-- SportType <===

INSERT INTO [SportType] (Title, UnitOfMeasurment)
VALUES ('��� �� 100 ������', '���')
INSERT INTO [SportType] (Title, UnitOfMeasurment)
VALUES ('������ � ������', '�')
INSERT INTO [SportType] (Title, UnitOfMeasurment)
VALUES ('�������� �� 200 ������ ������� ������', '���')

-- Performance <===

INSERT INTO [Performance] (Value, SportsmanId, CompetitionId, SportTypeId)
VALUES (10.5, 1, 1, 1)

INSERT INTO [Performance] (Value, SportsmanId, CompetitionId, SportTypeId)
VALUES (1.95, 2, 2, 2)

INSERT INTO [Performance] (Value, SportsmanId, CompetitionId, SportTypeId)
VALUES (3.5, 3, 3, 3)