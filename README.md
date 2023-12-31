# L'essentiel d'Azure Cosmos DB

Ce dossier Repository est lié au cours `L'essentiel d'Azure Cosmos DB`. Le cours entier est disponible sur [LinkedIn Learning][lil-course-url].

![Nom final de la formation][lil-thumbnail-url] 

En tant que développeur, vous êtes amené à travailler en langage SQL sur le cloud, sur des documents JSON ou sur du traitement de graphes. Si vous souhaitez gagner en rapidité et en souplesse, découvrez cette formation sur Azure Cosmos DB. Abordez le système de gestion de bases de données sur le cloud, multi-modèle, de Microsoft. Prenez en main Cosmos DB pour héberger vos données sur le cloud, sans gérer l'infrastructure, avec des performances et une disponibilité garanties. Parcourez également les API des différents modèles pour manipuler aisément des données documents, clé-valeur ou graphes. Rudi Bruchez, consultant expert en SQL Server, vous guide vers la maîtrise de Cosmos DB.

## Instructions

Dans la formation `L'essentiel d'Azure Cosmos DB`, nous développons des applications clients en C# pour accéder au différentes API d'Azure CosmosDB. Nous utilisons [Visual Studio Code](https://code.visualstudio.com/) pour développer nos applications, les déboguer et les exécuter.

## Installation

1. Pour utiliser ces fichiers d’exercice, vous avez besoin de : 
   - [Git](https://git-scm.com/), à installer bien sûr au préalable sur votre machine.
     - Installation sur Windows : vous pouvez utiliser [winget](https://learn.microsoft.com/fr-fr/windows/package-manager/winget/) : `winget install -e --id Git.Git` 
     <br />ou [Chocolatey](https://chocolatey.org/) : `choco install git` <br />ou [Scoop](https://scoop.sh/) : `scoop install git` <br />ou encore via [Git for Windows](https://gitforwindows.org/). <br />Je vous recommande winget, qui est bien intégré dans Windows et développé par Microsoft.
     - Installation sur Mac : vous pouvez utiliser [Homebrew](https://brew.sh/) : `brew install git`.
   - [Visual Studio Code](https://code.visualstudio.com/), à installer au préalable sur votre machine.
     - Installation sur Windows : avec l'installation téléchargeable sur le site de Visual Studio Code, <br />ou aussi via [winget](https://learn.microsoft.com/fr-fr/windows/package-manager/winget/) : `winget install -e --id Microsoft.VisualStudioCode`, <br />ou [Chocolatey](https://chocolatey.org/) : `choco install vscode`, <br />ou [Scoop](https://scoop.sh/) : `scoop install vscode`.
     - Installation sur Mac : vous pouvez utiliser [Homebrew](https://brew.sh/) : `brew install --cask visual-studio-code`.
   -  
2. Clonez ce dossier Repository sur votre machine locale (Mac), CMD ou Powershell (Windows), ou sur un outil GUI tel que SourceTree. L'URL à utiliser est disponible en cliquant sur le bouton vert `Code` en haut à droite de la page du dossier Repository sur GitHub. Prenez l'URL HTTPS et non pas SSH. Utilisez cette URL comme argument de la commande `git clone`. Pour plus d'instructions, suivez cette [aide en ligne de Github](https://docs.github.com/fr/repositories/creating-and-managing-repositories/cloning-a-repository).
3. Rendez-vous avec votre interpréteur de commandes dans un des sous-répertoires contenant un projet C#, et ouvrez le dossier dans Visual Studio Code avec la commande `code .`.

## Fichiers individuels

J'ai également déposé quelques fichiers individuels dans le dossier [fichiers-individuels](./fichiers-individuels/) pour vous laisser les requêtes que nous utilisons dans la formation selon les API explorées :

- Requêtes SQL utilisées dans l'API Core : [core-api.sql](./fichiers-individuels/core-api.sql) ;
- Le fichier JSON utilisé pour créer un nouveau rôle pour un accès sans mot de passe depuis notre programme client : [role.json](./fichiers-individuels/role.json) ;
- Deux fichiers de requêtes utilisés dans le chapitre sur l'API MongoDB : [mongo.js](./fichiers-individuels/mongo.js) et [mongo2.js](./fichiers-individuels/mongo2.js) ;
- Les requêtes Gremlin utilisées dans le chapitre sur l'API Grapge : [inscriptions.gremlin](./fichiers-individuels/inscriptions.gremlin).

## Formateur

**Rudi Bruchez** 

 Retrouvez mes autres formations sur [LinkedIn Learning][lil-URL-trainer].

[0]: # (Replace these placeholder URLs with actual course URLs)
[lil-course-url]: https://www.linkedin.com/learning/l-essentiel-d-azure-cosmos-db
[lil-thumbnail-url]: https://media.licdn.com/dms/image/D560DAQE6XnkUN27yNA/learning-public-crop_675_1200/0/1700129891211?e=2147483647&v=beta&t=jA62Sk1-5Q_dA-k3y8v_EEvsPL6Jm6_lJg_uB___iKI
[lil-URL-trainer]: https://www.linkedin.com/learning/instructors/rudi-bruchez

[1]: # (End of FR-Instruction ###############################################################################################)

