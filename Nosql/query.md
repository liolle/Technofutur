## Extraction 
1. Afficher le NOM et l’ADRESSE des clients habitant à Toulouse.

``` json 
{{'LOCALITE': 'Toulouse'},{}}
```
2. Afficher le NOM, le COMPTE et les COMMANDES des clients habitant à Poitiers.
``` json 
{{'LOCALITE': 'Poitiers'},{
    '_id': False, 
    'NOM': True, 
    'COMPTE': True, 
    'COMMANDES': True
}}
```
3. Afficher tous les champs sauf le champ CAT pour tous les clients
``` json 
{{'LOCALITE': 'Poitiers'},{'CAT': False}}
```
4. Afficher le DETAIL des COMMANDES.
``` json 
{{},{'COMMANDES.DETAILS': True}}
```

## Les opérateurs de recherche

1. Afficher le NOM des clients dont le COMPTE est strictement négatif.
``` json 
{{COMPTE: {$lt:0}},{}}
```

2. Afficher le NOM et la LOCALITE des clients dont le COMPTE est vide
``` json 
{{COMPTE: {$eq:0}},{LOCALITE:true,NOM:true}}
```

3. Afficher la LOCALITE des clients dont celle-ci est plus grande que Bruxelles.
``` json 
{{COMPTE: {$gt:"Bruxelles"}},{LOCALITE:true}}
```

4. Afficher le NOM, la LOCALITE des clients dont la LOCALITE n’est pas ‘Bruxelles’ ou ‘Poitiers’.
``` json 
{{LOCALITE: {$in:["Bruxelles","Poitiers"]} },{LOCALITE:true,NOM:true}}
```

## Les opérateurs conditionnels

1. Afficher le NOM des clients qui sont dans la CAT ‘B1’ et dont le compte est strictement positif.
``` json
{{$and:[{CAT:"B1"},{COMPTE:{$gt:0}}]},{LOCALITE:true}}}
```

2. Afficher le NOM des clients qui ont un COMPTE strictement négatif habitant à ‘Namur’.
``` json
{{$and:[{LOCALITE:"Namur"},{COMPTE:{$lt:0}}]},{NOM:true}}
```

3. Afficher le NOM des clients dont le compte est positif ou négatif et qui habitent à ‘Namur’ ou à ‘Lille’.
``` json
{{
  filter: {
    $and: [
      {
        $or: [
          {
            LOCALITE: 'Namur'
          },
          {
            LOCALITE: 'Lille'
          }
        ]
      },
      {
        $nor: [
          {
            COMPTE: {
              eq: 0
            }
          }
        ]
      }
    ]
  }
},{NOM:true}}
```

