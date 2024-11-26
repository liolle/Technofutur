-- 2.1.1 
select first_name fname, last_name lname from student

-- 2.1.2
SELECT (last_name +' '+ first_name) 'Full name', 
birth_date, 
birth_date,
year_result
FROM student

-- 2.1.3
SELECT (last_name +' '+ first_name) 'Full name', 
student_id, 
birth_date
FROM student

-- 2.1.4
SELECT 
    CONVERT(VARCHAR, student_id) + ' | ' +
    first_name + ' | ' +
    last_name + ' | ' +
    login + ' | ' +
    CONVERT(VARCHAR, section_id) + ' | ' +
    CONVERT(VARCHAR, birth_date, 120) + ' | ' +
    CONVERT(VARCHAR, year_result) + ' | ' +
    CONVERT(VARCHAR, course_id) AS 'Info Étudiant'
FROM student;

-- 2.2.1
SELECT 
    login,
	year_result
FROM student
WHERE year_result >16

--2.2.2
SELECT 
    last_name,
	section_id
FROM student
WHERE first_name = 'Georges'

--2.2.3
SELECT 
    first_name,
	year_result
FROM student
WHERE year_result BETWEEN 12 AND 16

--2.2.4
SELECT 
    first_name,
	section_id,
	year_result
FROM student
WHERE section_id NOT IN (1010,1020,1110);


--2.2.5
SELECT 
    last_name,
	section_id
FROM student
WHERE last_name LIKE '%r'

--2.2.6
SELECT 
    last_name,
	year_result
FROM student
WHERE last_name LIKE '__n%'
AND year_result >10;

--2.2.7
SELECT 
    last_name,
	year_result
FROM student
WHERE year_result <= 3
ORDER BY year_result DESC

--2.2.8
SELECT 
    (last_name +' '+ first_name) 'Nom complet',
	year_result
FROM student
WHERE section_id = 1010
ORDER BY year_result

--2.2.9
SELECT 
    last_name,
	section_id,
	year_result
FROM student
WHERE section_id IN (1010,1020)
AND year_result NOT BETWEEN 12 AND 18

--2.2.10
SELECT 
    last_name,
	section_id,
	year_result*5 'Résultat sur 100'
FROM student
WHERE section_id LIKE '13%' AND year_result*5 <=60

--2.3.1 
--2.3.2
/**
Parcequ'on compte le nombre de lige peut importe le contenue de celle-ci
*/

-- 2.3.3 faux
-- 2.3.4 faux
-- 2.3.5 vrai
-- 2.3.6 F, V, V
-- 2.3.7 
SELECT AVG(year_result)
FROM student

--2.3.8 
SELECT MAX(year_result)
FROM student

--2.3.9 
SELECT SUM(year_result)
FROM student

--2.3.10 
SELECT MIN(year_result)
FROM student

--2.3.11 
SELECT COUNT(year_result)
FROM student

--2.3.12 
SELECT login, YEAR(birth_date) AS 'Année de naissance'
FROM student
WHERE YEAR(birth_date) > 1970;

--2.3.13
SELECT login,last_name
FROM student
WHERE DATALENGTH(last_name) >= 8;

--2.3.14
SELECT UPPER(last_name) 'Nom de famille', first_name, year_result
FROM student
WHERE year_result >= 16
ORDER BY year_result DESC


--2.3.15
SELECT first_name, last_name, login, LOWER(SUBSTRING(first_name,1,2)+SUBSTRING(last_name,1,4)) 'Nouveau login'
FROM student
WHERE year_result BETWEEN 6 AND 10

--2.3.16

--2.3.17
SELECT last_name, login, year_result
FROM student
WHERE SUBSTRING(last_name,1,1) IN ('D','M','S');

--2.3.18
SELECT last_name, login, year_result
FROM student
WHERE year_result>10 
AND (year_result % 2) != 0
ORDER BY year_result DESC

--2.3.19
SELECT COUNT(last_name) 'Nbre de noms de plus de 7 lettres'
FROM student
WHERE DATALENGTH(last_name)>=7

--2.3.20
SELECT last_name, year_result,
CASE WHEN year_result >=12 THEN 'OK'
ELSE 'KO'
END 'Statut'
FROM student
WHERE YEAR(birth_date)<1955

--2.3.21
SELECT last_name, year_result,
CASE 
	WHEN year_result <10 THEN 'inférieur'
	WHEN year_result = 10 THEN 'neutre'
	ELSE 'supérieur'
END 'Statut'
FROM student
WHERE YEAR(birth_date) BETWEEN 1955 AND 1965

--2.3.22
SELECT last_name, year_result,
FORMAT(birth_date, 'd MMMM yyyy') AS 'Literal_date'
FROM student
WHERE YEAR(birth_date) BETWEEN 1975 AND 1985

--2.3.23
SELECT last_name, MONTH(birth_date) 'Mois de naissance',year_result, 
CASE 
	WHEN year_result = 4 THEN null
	ELSE year_result
END 'Nouveau résultat'
FROM student
WHERE  year_result < 7

--2.4.7
SELECT section_id, MAX(year_result) 'Résultat maximum'
FROM student
GROUP BY section_id

--2.4.8
SELECT section_id, AVG(CAST(year_result AS DECIMAL(25, 23))) 'Moyenne'
FROM student
WHERE section_id LIKE '10%'
GROUP BY section_id

--2.4.9
SELECT 
	MONTH(birth_date) 'Mois de naissance', 
	AVG(year_result) 'Moyenne'
FROM student
WHERE YEAR(birth_date) BETWEEN 1970 AND 1985
GROUP BY MONTH(birth_date)

--2.4.10
SELECT 
	section_id, 
	AVG(CAST(year_result AS DECIMAL(25, 23))) 'Moyenne'
FROM student
GROUP BY section_id
HAVING COUNT(section_id) >3

--2.4.11
SELECT 
	section_id, 
	AVG(year_result) 'Moyenne',
	MAX(year_result) 'Résutat maximum'
FROM student
GROUP BY section_id
HAVING AVG(year_result) >8

--2.5.6
SELECT 
	section_id, 
	course_id,
	AVG(CAST(year_result AS DECIMAL(10, 8))) 'Moyenne'
FROM student
WHERE section_id IN (1010,1320)
GROUP BY ROLLUP(section_id,course_id)

--2.5.7
SELECT 
	course_id,
	section_id, 
	AVG(CAST(year_result AS DECIMAL(10, 8))) 'Moyenne'
FROM student
WHERE section_id IN (1010,1320)
GROUP BY CUBE(course_id,section_id)

--2.6.1
SELECT 
	c.course_name,
	s.section_name,
	p.professor_name
FROM course c
LEFT JOIN professor p ON p.professor_id = c.professor_id
LEFT JOIN section s ON s.section_id = p.section_id

--2.6.2
SELECT 
	s.section_id,
	s.section_name,
	st.last_name
FROM section s
LEFT JOIN student st ON st.student_id  = s.delegate_id


--2.6.3
SELECT 
	s.section_id,
	s.section_name,
	p.professor_name
FROM section s
LEFT JOIN professor p ON p.section_id  = s.section_id

--2.6.4
SELECT 
	s.section_id,
	s.section_name,
	p.professor_name
FROM section s
LEFT JOIN professor p ON p.section_id  = s.section_id
WHERE p.professor_name IS NOT NULL

--2.6.5
SELECT
	s.last_name,
	s.year_result,
	g.grade
FROM student s
LEFT JOIN grade g ON s.year_result BETWEEN g.lower_bound AND g.upper_bound
WHERE s.year_result >= 12
ORDER BY g.grade

--2.6.6
SELECT
	p.professor_name,
	s.section_name,
	c.course_name,
	c.course_ects
FROM professor p
LEFT JOIN section s ON p.section_id = s.section_id
LEFT JOIN course c ON c.professor_id = p.professor_id
ORDER BY c.course_ects DESC

--2.6.7
SELECT
	p.professor_id,
	SUM(c.course_ects) 'ECTS_TOT'
FROM professor p
LEFT JOIN section s ON p.section_id = s.section_id
LEFT JOIN course c ON c.professor_id = p.professor_id
GROUP BY p.professor_id
ORDER BY 'ECTS_TOT' DESC

--2.6.8
SELECT 
	first_name,
	last_name,
	'S' 'Catégorie'
FROM student
WHERE DATALENGTH(last_name) >8
UNION 
SELECT 
	professor_name 'first_name',
	professor_surname 'last_name',
	'P' 'Catégorie'
FROM professor
WHERE DATALENGTH(professor_name) >8

--2.6.9
SELECT 
	s.section_id
FROM section s
LEFT JOIN professor p ON p.section_id = s.section_id
WHERE p.professor_id IS NULL

--2.7.1
SELECT 
	last_name,
	first_name,
	section_id
FROM student
WHERE section_id IN (
	SELECT st.section_id 
	FROM student st
	WHERE st.last_name = 'Roberts'
) AND last_name != 'Roberts'


--2.7.2
SELECT 
	last_name,
	first_name,
	year_result
FROM student
WHERE year_result > 2* (
	SELECT AVG(year_result)
	FROM student
)

--2.7.3
SELECT 
	section_id,
	section_name
FROM section
WHERE section_id NOT IN (
	SELECT professor.section_id
	FROM professor
)

--2.7.4
SELECT 
	last_name,
	first_name,
	FORMAT(birth_date,'MM/dd/yyyy'),
	year_result
FROM student
WHERE MONTH(birth_date) = (
	SELECT MONTH(professor.professor_hire_date)
	FROM professor
	WHERE professor_name = 'Giot'
)
ORDER BY year_result DESC

--2.7.5
SELECT 
	s.last_name,
	s.first_name,
	s.year_result
FROM student s
LEFT JOIN grade g ON s.year_result BETWEEN g.lower_bound AND g.upper_bound
WHERE g.grade = 'TB'