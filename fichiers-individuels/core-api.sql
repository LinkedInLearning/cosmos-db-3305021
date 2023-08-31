SELECT * FROM Inscriptions i WHERE i.Nom LIKE 'F%'

SELECT COUNT(1) FROM Inscriptions i WHERE i.Nom LIKE 'F%'

SELECT i.Nom, i.Prenom FROM Inscriptions i WHERE i.Nom LIKE 'F%'

SELECT VALUE {
    inscrit: CONCAT(i.Prenom, ' ', i.Nom),
    formation: i.Titre
}
FROM Inscriptions i
WHERE i.Nom LIKE 'F%'

SELECT {
    inscrit: CONCAT(i.Prenom, ' ', i.Nom),
    formation: i.Titre
}
FROM Inscriptions i
WHERE i.Nom LIKE 'F%'
ORDER BY i.Titre

SELECT {
    inscrit: CONCAT(i.Prenom, ' ', i.Nom),
    formation: i.Titre
}
FROM Inscriptions i
WHERE i.Nom LIKE 'F%'
ORDER BY i.Titre
OFFSET 1 LIMIT 5

SELECT i.Titre, 
COUNT(1) as cnt
FROM Inscriptions i
GROUP BY i.Titre
ORDER BY i.Titre



SELECT VALUE
    {
        Inscrit: CONCAT(i.Prenom, ' ', i.Nom), 
        Formation: i.Titre
    }
FROM Inscriptions i
WHERE i.Nom LIKE 'F%'
ORDER BY i.Titre
OFFSET 1 LIMIT 5
