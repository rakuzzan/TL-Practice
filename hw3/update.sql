UPDATE [Coach]
SET FirstName = '�����'
WHERE CoachId = 1;

UPDATE [Sportsman]
SET LastName = '������'
WHERE LastName LIKE '����%';

UPDATE [Competition]
SET Venue = '������, ����, ����������� ������� �����'
WHERE Date BETWEEN '2023-08-01' AND '2023-08-31';

UPDATE [SportType]
SET Title = '�������� 100 ������'
WHERE Title IN ('��� �� 100 ������', '������ � ������');

UPDATE [Performance]
SET Value = 11.2
WHERE SportsmanId = 1 AND CompetitionId = 1 AND SportTypeId = 1;