NetPostgresProjet - Système de Gestion Hospitalière
📋 Description
Système de gestion hospitalière complet développé en C# avec une architecture 3 couches (DAL, BLL, PL) utilisant .NET et PostgreSQL. Ce projet permet de gérer les patients, rendez-vous, hospitalisations, pharmacie, ressources humaines et facturation.

🏗️ Architecture
Architecture 3 Couches
NetPostgresProjet/
│
├── NetPostgresProjet.DAL/        # Data Access Layer
│   ├── Entities/                 # Entités de base de données
│   ├── Repositories/             # Repositories pour l'accès aux données
│   ├── Data/                     # DbContext et configurations
│   └── Injections/               # Configuration des injections de dépendances
│
├── NetPostgresProjet.BLL/        # Business Logic Layer
│   ├── DTOs/                     # Data Transfer Objects
│   ├── Services/                 # Services métier
│   ├── Common/Mappings/          # Configuration AutoMapper
│   └── DepencyInjection.cs       # Configuration des services
│
└── NetPostgresProjet.PL/         # Presentation Layer
    ├── Controllers/              # Contrôleurs API
    └── Program.cs                # Point d'entrée de l'application
🚀 Fonctionnalités
👥 Gestion des Patients
Création et mise à jour des dossiers patients
Recherche de patients par critères multiples
Archivage et réactivation des dossiers
Gestion des médecins traitants
📅 Gestion des Rendez-vous
Création et planification de rendez-vous
Gestion des consultations, visites et téléconsultations
Planning des médecins et services
Vérification de disponibilité
Confirmation et annulation de rendez-vous
🏥 Gestion Hospitalière
Création et suivi des hospitalisations
Gestion des chambres et lits
Transfert de chambres
Statistiques d'occupation
💊 Pharmacie
Gestion du stock de médicaments
Mouvements de stock (entrée, sortie, ajustement)
Alertes de rupture et péremption
Prescriptions et dispensations
Commandes fournisseurs
💼 Ressources Humaines
Gestion des employés
Gestion des présences
Génération des bulletins de salaire
Gestion des contrats
Statistiques RH
💰 Facturation
Génération de factures
Gestion des paiements
Suivi des factures impayées
Statistiques de facturation
📊 Reporting
Dashboard avec indicateurs clés
Statistiques par domaine
Rapports personnalisés
🛠️ Technologies Utilisées
Framework: .NET 6.0+
Langage: C# 10
Base de données: PostgreSQL
ORM: Entity Framework Core
Mapping: AutoMapper
API: ASP.NET Core Web API
Validation: Data Annotations
📦 Packages NuGet Requis
<!-- DAL -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.*" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="7.0.*" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.*" />

<!-- BLL -->
<PackageReference Include="AutoMapper" Version="12.0.*" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.*" />

<!-- PL -->
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="7.0.*" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.*" />
⚙️ Configuration
1. Configuration de la Base de Données
2. Configuration dans Program.cs
3.🚦 Installation et Démarrage
Prérequis
.NET SDK 6.0 ou supérieur
PostgreSQL 12 ou supérieur
Visual Studio 2022 ou VS Code
Étapes d'installation
Cloner le projet
git clone https://github.com/votre-repo/NetPostgresProjet.git
cd NetPostgresProjet
Restaurer les packages NuGet
dotnet restore
Configurer la base de données

Créer une base de données PostgreSQL
Mettre à jour la chaîne de connexion dans appsettings.json
Créer les migrations

cd NetPostgresProjet.DAL
dotnet ef migrations add InitialCreate --startup-project ../NetPostgresProjet.PL
dotnet ef database update --startup-project ../NetPostgresProjet.PL
Lancer l'application
cd ../NetPostgresProjet.PL
dotnet run
Accéder à Swagger
Ouvrir le navigateur à l'adresse: https://localhost:5001/swagger
📚 Structure des Entités Principales
Patient
Informations personnelles (nom, prénom, date de naissance)
Contact (téléphone, email, adresse)
Numéro de sécurité sociale
Médecin traitant
Groupe sanguin
Rendez-vous
Patient et médecin
Date et heure (début/fin)
Type (consultation, visite, téléconsultation)
Statut (programmé, annulé, effectué, no-show)
Hospitalisation
Patient, chambre et lit
Dates d'entrée et sortie
Motif d'hospitalisation
Statut (planifiée, en cours, terminée)
Médicament
Nom, description, catégorie
Prix et stock
Date d'expiration
Seuils d'alerte
Employé
Informations personnelles
Poste et service
Contrat et salaire
Présences
🔌 API Endpoints Principaux
Patients
GET /api/patients - Liste des patients
GET /api/patients/{id} - Détails d'un patient
POST /api/patients - Créer un patient
PUT /api/patients/{id} - Modifier un patient
DELETE /api/patients/{id} - Supprimer un patient
Rendez-vous
GET /api/rendezvous - Liste des rendez-vous
POST /api/rendezvous - Créer un rendez-vous
PUT /api/rendezvous/{id} - Modifier un rendez-vous
POST /api/rendezvous/{id}/confirmer - Confirmer un rendez-vous
Hospitalisations
GET /api/hospitalisations - Liste des hospitalisations
POST /api/hospitalisations - Créer une hospitalisation
POST /api/hospitalisations/{id}/commencer - Démarrer une hospitalisation
POST /api/hospitalisations/{id}/terminer - Terminer une hospitalisation
Pharmacie
GET /api/medicaments - Liste des médicaments
POST /api/stock/mouvements - Enregistrer un mouvement de stock
GET /api/stock/alertes - Alertes de stock
POST /api/prescriptions - Créer une prescription
🔒 Bonnes Pratiques Implémentées
✅ Séparation des responsabilités (Architecture 3 couches)
✅ Injection de dépendances (DI)
✅ Repository Pattern pour l'accès aux données
✅ DTOs pour le transfert de données
✅ AutoMapper pour le mapping automatique
✅ Validation des données avec Data Annotations
✅ Gestion des erreurs avec try-catch et logging
✅ Async/Await pour les opérations asynchrones
📝 DTOs Disponibles
Création (Create)
CreatePatientDto, CreateRendezVousDto, CreateHospitalisationDto
CreateMedicamentDto, CreatePrescriptionDto, CreateCommandeDto
CreateFactureDto, CreatePaiementDto
Mise à jour (Update)
UpdatePatientDto, UpdateRendezVousDto, UpdateHospitalisationDto
UpdateMedicamentDto, UpdateFactureDto
Transfert (Standard)
PatientDto, RendezVousDto, HospitalisationDto
MedicamentDto, PrescriptionDto, FactureDto
EmployeDto, PresenceDto, ContratDto
Statistiques
DashboardDto, StatistiquesActesDto
StatistiquesFacturationDto, StatistiquesRHDto
StatistiquesPharmacieDto, StatistiquesHospitalisationDto
🧪 Tests
# Exécuter les tests unitaires
dotnet test

# Avec couverture de code
dotnet test /p:CollectCoverage=true
