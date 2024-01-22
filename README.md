# Airforce Project (EN)

## Overview

The Airforce project is composed of several sub-projects that collectively form a comprehensive aviation-themed application. The core application is a Windows Presentation Foundation (WPF) app, utilizing the Model-View-ViewModel (MVVM) architecture for a robust and maintainable codebase. In addition, a web representation of the project is provided, built with the principles of Inversion of Control (IoC), Dependency Injection (DI), and the Model-View-Controller (MVC) design pattern.

## Sub-Projects

### Airforce

This is the main WPF application that presents the user interface for the Airforce project. It integrates components from other projects for a complete user experience.

### Airforce.BLC (Business Logic Component)

Contains the business logic and rules that govern the application. It is referenced by the main Airforce project to separate concerns and enhance modularity.

### Airforce.Core

Houses shared resources, utilities, and core functionality that are utilized across the entire solution.

### Airforce.DBFile

Manages file-based data storage, providing functionality to read from and write to file systems.

### Airforce.DBMock

Provides mock implementations of database functionality for testing purposes without the need for actual database interaction.

### Airforce.DBSQL

Deals with SQL-based database operations, containing all SQL queries and database interaction logic.

### Airforce.Interfaces

Defines interfaces for the various components, ensuring a contract-based development approach and facilitating Dependency Injection.

### Airforce.Web

The web representation of the Airforce project, built using MVC architecture. It uses IoC and DI to provide a modular and testable web application.

## Workflow

### Database Sub-Projects

The `DBMOCK`, `DBFILE`, and `DBSQL` projects are designed to be directly integrated into the main Airforce WPF application. They allow for different modes of data management and can be swapped out based on the environment (development, testing, production).

### WPF Application

The Airforce WPF application is built using the MVVM architecture. This design pattern enables a clear separation between the user interface (View), the data and business logic (Model), and the interaction logic (ViewModel). It makes the application easier to test, maintain, and evolve.

### Web Application

The web project, Airforce.Web, follows the MVC architecture, complemented by IoC and DI patterns. This structure allows for decoupled components, making the web application more scalable and easier to manage. It serves as a web-based counterpart to the WPF application, ensuring that the application can be accessed through various platforms.


### ---------------

# Projekt Airforce (PL)

## Przegląd

Projekt Airforce składa się z kilku podprojektów, które razem tworzą kompleksową aplikację o tematyce lotniczej. Aplikacja główna to aplikacja Windows Presentation Foundation (WPF), wykorzystująca architekturę Model-View-ViewModel (MVVM) dla zapewnienia solidnej i łatwej w utrzymaniu bazy kodu. Dodatkowo, dostarczona jest reprezentacja webowa projektu, zbudowana z zasadami Inversion of Control (IoC), Dependency Injection (DI) i wzorca projektowego Model-View-Controller (MVC).

## Podprojekty

### Airforce

To główna aplikacja WPF, która prezentuje interfejs użytkownika dla projektu Airforce. Integruje komponenty z innych projektów dla kompleksowego doświadczenia użytkownika.

### Airforce.BLC (Business Logic Component)

Zawiera logikę biznesową i reguły, które rządzą aplikacją. Jest odniesieniem dla głównego projektu Airforce w celu oddzielenia zagadnień i zwiększenia modularności.

### Airforce.Core

Zawiera wspólne zasoby, narzędzia i podstawowe funkcjonalności, które są wykorzystywane w całym rozwiązaniu.

### Airforce.DBFile

Zarządza przechowywaniem danych opartym o pliki, dostarczając funkcjonalności odczytu i zapisu do systemów plików.

### Airforce.DBMock

Dostarcza atrapowe implementacje funkcjonalności bazy danych do celów testowych bez potrzeby rzeczywistej interakcji z bazą danych.

### Airforce.DBSQL

Zajmuje się operacjami bazodanowymi opartymi o SQL, zawierając wszystkie zapytania SQL i logikę interakcji z bazą danych.

### Airforce.Interfaces

Definiuje interfejsy dla różnych komponentów, zapewniając podejście oparte na kontraktach i ułatwiając Iniekcję Zależności.

### Airforce.Web

Reprezentacja webowa projektu Airforce, zbudowana z wykorzystaniem architektury MVC. Używa IoC i DI dla zapewnienia modularności i testowalności aplikacji webowej.

## Przepływ pracy

### Podprojekty bazy danych

Projekty `DBMOCK`, `DBFILE` i `DBSQL` są zaprojektowane do bezpośredniej integracji z główną aplikacją Airforce WPF. Pozwalają na różne tryby zarządzania danymi i mogą być wymieniane w zależności od środowiska (rozwój, testowanie, produkcja).

### Aplikacja WPF

Aplikacja Airforce WPF jest zbudowana przy użyciu architektury MVVM. Ten wzorzec projektowy umożliwia wyraźne oddzielenie interfejsu użytkownika (Widok), danych i logiki biznesowej (Model) oraz logiki interakcji (ViewModel). Sprawia to, że aplikacja jest łatwiejsza w testowaniu, utrzymaniu i rozwoju.

### Aplikacja Webowa

Projekt webowy, Airforce.Web, podąża za architekturą MVC, uzupełnioną o IoC i DI. Struktura ta pozwala na rozłączone komponenty, czyniąc aplikację webową bardziej skalowalną i łatwiejszą w zarządzaniu. Służy jako webowa odpowiednik aplikacji WPF, zapewniając dostęp do aplikacji poprzez różne platformy.

