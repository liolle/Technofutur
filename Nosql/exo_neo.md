## Partie 1 DML 


### 2 
``` js
// Person
CREATE (p1:Person {name: "Orlando Santos"})
CREATE (p2:Person {name: "Albert Van de Bergh"})
CREATE (p3:Person {name: "Anna Karénine"})
CREATE (p4:Person {name: "John Smith"})
CREATE (p5:Person {name: "Léon Tolstoï"})

// Jury
CREATE (j1:Jury {email: "AnnaKarénine@email.com"})
CREATE (j2:Jury {email: "JohnSmith@email.com"})

// Country
CREATE (c1:Country {name: "Belgium"})
CREATE (c3:Country {name: "Germany"})


//Locality
CREATE (l1:Locality {name: "Bruxelles"})
CREATE (l2:Locality {name: "Munich"})

// Restaurant
CREATE (r1:Restaurant {name: "Don Quijote", speciality: "spanish dishes"})
CREATE (r2:Restaurant {name: "La patate roulante", speciality: "Frites"})

// Notes
CREATE (n1:Note {score: 2})
CREATE (n2:Note {score: 4})
CREATE (n3:Note {score: 5})
CREATE (n4:Note {score: 5})
CREATE (n5:Note {score: 0})
CREATE (n6:Note {score: 4})

// Restaurant owners relation 
CREATE (p1)-[:OWNS]->(r1)
CREATE (p2)-[:OWNS]->(r2)

// Locality
CREATE (r1)-[:LOCATED_IN]->(l2)
CREATE (l2)-[:IN_COUNTRY]->(c3)
CREATE (r2)-[:LOCATED_IN]->(l1)
CREATE (l1)-[:IN_COUNTRY]->(c1)

// Relatives
CREATE (p5)-[:FATHER_OF]->(p3)
CREATE (p3)-[:MARRIED_TO]->(p4)
CREATE (p5)-[:FRIEND_WITH]->(p2)

//Jury members
CREATE (p3)-[:IS_JURY]->(j1)
CREATE (p4)-[:IS_JURY]->(j2)

// Notations
CREATE (j1)-[:GAVE]->(n1)
CREATE (j1)-[:GAVE]->(n3)
CREATE (j2)-[:GAVE]->(n2)
CREATE (j2)-[:GAVE]->(n3) 
CREATE (p1)-[:GAVE]->(n5)  
CREATE (p2)-[:GAVE]->(n6)  

CREATE (n1)-[:TO]->(r1)  
CREATE (n3)-[:TO]->(r2)  
CREATE (n2)-[:TO]->(r1)  
CREATE (n3)-[:TO]->(r2)  
CREATE (n5)-[:TO]->(r2)  
CREATE (n6)-[:TO]->(r1)
```


#### airline company 

[airlines](https://gitlab.com/fovyn/neo4j-cdn/-/raw/main/openflights/airlines.csv?ref_type=heads)
[airports](https://gitlab.com/fovyn/neo4j-cdn/-/raw/main/openflights/aiports.csv?ref_type=heads)
[routes](https://gitlab.com/fovyn/neo4j-cdn/-/raw/main/openflights/routes.csv?ref_type=heads)

