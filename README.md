# WebServiceServer

### Configuration MongoDB (appsettings.json)

"MovieDatabaseSettings": {
    "UserCollectionName": "User",
    "LikeCollectionName": "Like",
    "SuggestionCollectionName": "Suggestion",
    "ConnectionString": "mongodb://localhost:xxxxx",
    "DatabaseName": "MovieDB"
  }
 
### Features
 - Système de changement d'utilisateur => Entrer un nom dans le champ correspondant puis cliquer sur OK. (Connecté si existe, créé si non)
 - Ajout/Retrait des favoris => En cliquant sur un media, on peut voir le nombre d'utilisateurs ayant ajouté le média à ses favoris
 - Suggestion auprès d'un autre profil => Possibilité de suggérer à un autre utilisateur un média. L'utilisateur peut voir le nb de fois où le média sélectionné lui a été recommandé

### Mis en stand-By par manque de temps (pas de problématique technique)
- Page "Mes Favoris"
- Page "Mes Suggestions"
- Notation d'un media
